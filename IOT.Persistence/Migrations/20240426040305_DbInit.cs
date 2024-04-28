using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOT.Persistence.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWorking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerId);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotorOperationTime = table.Column<double>(type: "float", nullable: false),
                    MotorMaintenanceTime = table.Column<double>(type: "float", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machine_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    DetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DetailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTimePre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimePre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailStatus = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_Detail_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerPicture",
                columns: table => new
                {
                    WorkerPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileData = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerPicture", x => new { x.WorkerPictureId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_WorkerPicture_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicLog",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTagging = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTagging = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MachineId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicLog", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_ElectronicLog_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineError",
                columns: table => new
                {
                    MachineErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineError", x => x.MachineErrorId);
                    table.ForeignKey(
                        name: "FK_MachineError_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachinePicture",
                columns: table => new
                {
                    MachinePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileData = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachinePicture", x => new { x.MachinePictureId, x.MachineName });
                    table.ForeignKey(
                        name: "FK_MachinePicture_Machine_MachineName",
                        column: x => x.MachineName,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OEE",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdleTime = table.Column<float>(type: "real", nullable: false),
                    ShiftTime = table.Column<float>(type: "real", nullable: false),
                    OperationTime = table.Column<float>(type: "real", nullable: false),
                    Oee = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OEE", x => new { x.TimeStamp, x.MachineId });
                    table.ForeignKey(
                        name: "FK_OEE_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailLog",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTagging = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTagging = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MachineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailLog", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_DetailLog_Detail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Detail",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailLog_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailLog_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailPicture",
                columns: table => new
                {
                    DetailPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileData = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPicture", x => new { x.DetailPictureId, x.DetailId });
                    table.ForeignKey(
                        name: "FK_DetailPicture_Detail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Detail",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_ProjectId",
                table: "Detail",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailLog_DetailId",
                table: "DetailLog",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailLog_MachineId",
                table: "DetailLog",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailLog_WorkerId",
                table: "DetailLog",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPicture_DetailId",
                table: "DetailPicture",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicLog_MachineId",
                table: "ElectronicLog",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_AreaId",
                table: "Machine",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineError_MachineId",
                table: "MachineError",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachinePicture_MachineName",
                table: "MachinePicture",
                column: "MachineName");

            migrationBuilder.CreateIndex(
                name: "IX_OEE_MachineId",
                table: "OEE",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPicture_WorkerId",
                table: "WorkerPicture",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailLog");

            migrationBuilder.DropTable(
                name: "DetailPicture");

            migrationBuilder.DropTable(
                name: "ElectronicLog");

            migrationBuilder.DropTable(
                name: "MachineError");

            migrationBuilder.DropTable(
                name: "MachinePicture");

            migrationBuilder.DropTable(
                name: "OEE");

            migrationBuilder.DropTable(
                name: "WorkerPicture");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
