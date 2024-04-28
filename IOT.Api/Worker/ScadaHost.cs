using IOT.Api.Hubs;
using IOT.Api.MQTTModels;
using IOT.Application.Contract.Email;
using IOT.Application.Contract.Gmail;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Models.Email;
using IOT.Application.Models.Gmail;
using IOT.Domain;
using IOT.Infastructure.Communication;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace IOT.Api.Worker;

public class ScadaHost : BackgroundService
{
    private readonly ManagedMqttClient _mqttClient;
    private readonly Buffer _buffer;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IGmailSender _gmailSender;
    //private readonly IEmailSender _emailSender;
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceScopeFactory _scopeFactory;



    public ScadaHost(ManagedMqttClient mqttClient, Buffer buffer,
        IHubContext<NotificationHub> hubContext,
        IServiceScopeFactory scopeFactory,
        IGmailSender gmailSender
        //IEmailSender emailSender,
        //IUnitOfWork unitOfWork
        )
    {
        _mqttClient = mqttClient;
        _buffer = buffer;
        _hubContext = hubContext;
        _gmailSender = gmailSender;
        //_emailSender = emailSender;
        //_unitOfWork = unitOfWork;
        _scopeFactory = scopeFactory;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await ConnectToMqttBrokerAsync();
    }

    private async Task ConnectToMqttBrokerAsync()
    {
        _mqttClient.MessageReceived += OnMqttClientMessageReceivedAsync;
        await _mqttClient.ConnectAsync();
        await _mqttClient.Subscribe("FABLAB/+/+/+/+");
		//FABLAB/MACHANICAL_MACHINES/KB30/Metric/OEE
		await _mqttClient.Subscribe("FABLAB/+/+/+");
		//FABLAB/Environment/Metric/Humidity
	}

	private async Task OnMqttClientMessageReceivedAsync(MqttMessage e)
    {
        var topic = e.Topic;
        var payloadMessage = e.Payload;
        if (topic is null || payloadMessage is null)
        {
            return;
        }
        var topicSegments = topic.Split('/');
        var topic1 = topicSegments[1];



        payloadMessage = payloadMessage.Replace("false", "\"FALSE\"");
        payloadMessage = payloadMessage.Replace("true", "\"TRUE\"");
        payloadMessage = payloadMessage.Replace("[", "");
        payloadMessage = payloadMessage.Replace("]", "");


        switch (topic1)
        {
            // gửi chỉ số oee, xử lí lưu database, gửi lên web
            case "MACHANICAL_MACHINES":


                switch (topicSegments[4]) 
                {
					case "OEE":
						var machineId = topicSegments[2];
						var oee = JsonConvert.DeserializeObject<OeeRecieve>(payloadMessage);
						var A = oee.idleTime / oee.shiftTime;
						var P = oee.operationTime / oee.idleTime;
						var oeeDb = new OEE
						{
							MachineId = machineId,
							IdleTime = oee.idleTime,
							ShiftTime = oee.shiftTime,
							OperationTime = oee.operationTime,
							TimeStamp = oee.timestamp,
							Oee = A * P
						};
						try
						{
							using (var scope = _scopeFactory.CreateScope())
							{
								var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

								_unitOfWork.oeeRepository.Add(oeeDb);
								await _unitOfWork.CompleteAsync();

							}
						}
						catch (Exception ex)
						{
							throw ex;
						}

						string jsonDb = JsonConvert.SerializeObject(oeeDb);
                        // ten chu de, ten may, value
						var notification = new TagChangedNotification(topicSegments[4], machineId, jsonDb);
						_buffer.Update(notification);

						var oeeSend = new OeeSend
						{
							DeviceId = machineId,
							IdleTime = oee.idleTime,
							OperationTime = oee.shiftTime,
							Oee = A * P,
							ShiftTime = oee.shiftTime,
							Timestamp = oee.timestamp,
							Topic = topic1,
						};
						string jsonNoti = JsonConvert.SerializeObject(oeeSend);
						jsonNoti = jsonNoti.Replace("\\", "");
						jsonNoti = jsonNoti.Replace("\r", "");
						jsonNoti = jsonNoti.Replace("\n", "");
					//	jsonNoti = jsonNoti.Replace(" ", "");
						await _hubContext.Clients.All.SendAsync("OeeChanged", jsonNoti);

						break;
                    case "Vibration":
                    case "Speed":
                    case "Power":
					case "MachineStatus":
					case "Operator":
                        var data = JsonConvert.DeserializeObject<TempleteObject>(payloadMessage);
                        var dataSend = new DataMachineSend
                        {
                            machineId = topicSegments[2],
                            name= data.name,
                            timestamp = data.timestamp.ToString(), 
                            value = data.value
                        };
                        string dataMachine = JsonConvert.SerializeObject(dataSend);
						await _hubContext.Clients.All.SendAsync("DataMachineChanged", dataMachine);
						var dataMachineBuffer = new TagChangedNotification(topicSegments[4], topicSegments[2], dataMachine);
						_buffer.Update(dataMachineBuffer);
						break;
					case "MaterialCodeProducting":
						var detailOperating = JsonConvert.DeserializeObject<DetailUpdate>(payloadMessage);
						try
						{
							using (var scope = _scopeFactory.CreateScope())
							{
								var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();


								var detail = await _unitOfWork.detailRepository.GetByIdAsync(detailOperating.value);
								if (detail != null && detail.DetailStatus == DetailStatus.preparing)//&& detail.DetailStatus==DetailStatus.preparing
								{
									detail.DetailStatus = DetailStatus.working;
									_unitOfWork.detailRepository.Update(detail);

									var detailLog = new DetailLog()
									{
										DetailId = detailOperating.value,
										StartTagging = detailOperating.timestamp,
										MachineId = topicSegments[2],

										WorkerId = detailOperating.operatorid
									};
									_unitOfWork.detailLogRepository.Add(detailLog);
								}
								//




								await _unitOfWork.CompleteAsync();

							}
						}
						catch (Exception ex)
						{
							throw ex;
						}
						break;


					case "MaterialCodeDone":
						var detailOperated = JsonConvert.DeserializeObject<DetailUpdate>(payloadMessage);
						try
						{
							using (var scope = _scopeFactory.CreateScope())
							{
								var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

								var detail = await _unitOfWork.detailRepository.GetByIdAsync(detailOperated.value);

								if (detail != null && detail.DetailStatus == DetailStatus.working)
								{
									var detailLogs =  _unitOfWork.detailLogRepository.FindAll(true).ToList();
									var detailLog = detailLogs
										.Where(x => x.DetailId == detailOperated.value)
										.Where(x => x.WorkerId == detailOperated.operatorid)
										.Where(x => x.MachineId == topicSegments[2])
										.FirstOrDefault();
									detailLog.EndTagging = detailOperated.timestamp;
								
									_unitOfWork.detailLogRepository.Update(detailLog);
								}
								await _unitOfWork.CompleteAsync();

							}
						}
						catch (Exception ex)
						{
							throw ex;
						}

						break;

					case "Maintenance":
						var MachhineLog = JsonConvert.DeserializeObject<TempleteObject>(payloadMessage);
						try
						{
							using (var scope = _scopeFactory.CreateScope())
							{
								var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
								

								var machine = await _unitOfWork.machineRepository.GetByIdAsync(topicSegments[2]);
								if (machine != null)
								{
									machine.MotorMaintenanceTime +=Double.Parse(MachhineLog.value);
									_unitOfWork.machineRepository.Update(machine);

								}
								await _unitOfWork.CompleteAsync();
							}
						}
						catch (Exception ex)
						{
							throw ex;
						}
						break;
					case "MachineStatusOn":
						var electricLogOn = JsonConvert.DeserializeObject<MachineStatus>(payloadMessage);
						try
						{
							using (var scope = _scopeFactory.CreateScope())
							{
								var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
								var machineLog = new ElectronicLog
								{
									MachineId = topicSegments[2],
									StartTagging = electricLogOn.timestamp,
									EndTagging = null,
									//MachineId = topicSegments[2],
								};
								_unitOfWork.electronicLogRepository.Add(machineLog);
	
								await _unitOfWork.CompleteAsync();
							}
						}
						catch (Exception ex)
						{
							throw ex;
						}
						break;

					case "MachineStatusOff":
						var electricLogOff = JsonConvert.DeserializeObject<MachineStatus>(payloadMessage);
						try
						{
							using (var scope = _scopeFactory.CreateScope())
							{
								var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
								var electronicLogs = _unitOfWork.electronicLogRepository.FindAll(true).ToList();
								var machineLog = electronicLogs
									.Where(x => x.MachineId == topicSegments[2])
									.Where(x => x.StartTagging <= electricLogOff.timestamp)
									.Where(x => x.EndTagging == null)
									.OrderByDescending(x => x.LogId)
									.First();
								machineLog.EndTagging = electricLogOff.timestamp;
								_unitOfWork.electronicLogRepository.Update(machineLog);

								await _unitOfWork.CompleteAsync();
							}
						}
						catch (Exception ex)
						{
							throw ex;
						}
						break;

				}
                


                break;
            case "Environment":
				var environment = JsonConvert.DeserializeObject<TempleteObject>(payloadMessage);
                var environmentSend = new EnvironmentSend
                {
                    name = environment.name,
                    timestamp = environment.timestamp.ToString(),
                    value = environment.value,
                    sensorId = topicSegments[3]
                };

				string jsonEnvironment = JsonConvert.SerializeObject(environmentSend);
                // moi truong/ ten cam bien/ value
                var envirBuffer = new TagChangedNotification(topicSegments[1], topicSegments[3], jsonEnvironment);
                _buffer.Update(envirBuffer);
				await _hubContext.Clients.All.SendAsync("EnvironmentChanged", jsonEnvironment);

				break;





            

        }







    }
}
