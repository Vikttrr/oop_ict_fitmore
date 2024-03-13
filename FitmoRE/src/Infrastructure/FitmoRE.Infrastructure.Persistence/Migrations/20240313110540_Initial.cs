using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitmoRE.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Branch",
            columns: table => new
            {
                branchId = table.Column<string>(type: "text", nullable: false),
                address = table.Column<string>(type: "text", nullable: true),
                workinghours = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("Branch_pkey", x => x.branchId);
            });

        migrationBuilder.CreateTable(
            name: "Client",
            columns: table => new
            {
                clientid = table.Column<string>(type: "text", nullable: false),
                fullname = table.Column<string>(type: "text", nullable: true),
                dateofbirth = table.Column<DateOnly>(type: "date", nullable: true),
                phonenumber = table.Column<string>(type: "text", nullable: true),
                email = table.Column<string>(type: "text", nullable: true),
                isactive = table.Column<bool>(type: "boolean", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("Client_pkey", x => x.clientid);
            });

        migrationBuilder.CreateTable(
            name: "Employee",
            columns: table => new
            {
                employeeId = table.Column<string>(type: "text", nullable: false),
                fullname = table.Column<string>(type: "text", nullable: true),
                phonenumber = table.Column<string>(type: "text", nullable: true),
                email = table.Column<string>(type: "text", nullable: true),
                startdate = table.Column<DateOnly>(type: "date", nullable: true),
                workschedule = table.Column<DateOnly>(type: "date", nullable: true),
                position = table.Column<string>(type: "text", nullable: true),
                isactive = table.Column<bool>(type: "boolean", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("Employee_pkey", x => x.employeeId);
            });

        migrationBuilder.CreateTable(
            name: "TariffCategory",
            columns: table => new
            {
                tariffcategoryid = table.Column<string>(type: "text", nullable: false),
                category = table.Column<char>(type: "char", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("TariffCategory_pkey", x => x.tariffcategoryid);
            });

        migrationBuilder.CreateTable(
            name: "TariffType",
            columns: table => new
            {
                tarifftypeid = table.Column<string>(type: "text", nullable: false),
                type = table.Column<char>(type: "char", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("TariffType_pkey", x => x.tarifftypeid);
            });

        migrationBuilder.CreateTable(
            name: "GymRoom",
            columns: table => new
            {
                roomid = table.Column<string>(type: "text", nullable: false),
                roomnumber = table.Column<string>(type: "text", nullable: true),
                space = table.Column<int>(type: "integer", nullable: true),
                temperature = table.Column<double>(type: "double precision", nullable: true),
                capacity = table.Column<int>(type: "integer", nullable: true),
                branchid = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("GymRoom_pkey", x => x.roomid);
                table.ForeignKey(
                    name: "GymRoom_branchid_fkey",
                    column: x => x.branchid,
                    principalTable: "Branch",
                    principalColumn: "branchId");
            });

        migrationBuilder.CreateTable(
            name: "Payment",
            columns: table => new
            {
                paymentid = table.Column<string>(type: "text", nullable: false),
                clientid = table.Column<string>(type: "text", nullable: true),
                date = table.Column<DateOnly>(type: "date", nullable: true),
                amount = table.Column<decimal>(type: "numeric", nullable: true),
                ispaid = table.Column<bool>(type: "boolean", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("Payment_pkey", x => x.paymentid);
                table.ForeignKey(
                    name: "Payment_clientid_fkey",
                    column: x => x.clientid,
                    principalTable: "Client",
                    principalColumn: "clientid");
            });

        migrationBuilder.CreateTable(
            name: "Tariff",
            columns: table => new
            {
                tariffid = table.Column<string>(type: "text", nullable: false),
                tariffcategoryid = table.Column<string>(type: "text", nullable: true),
                tarifftypeid = table.Column<string>(type: "text", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("tariffid", x => x.tariffid);
                table.ForeignKey(
                    name: "Tariff_tariffcategoryid_fkey",
                    column: x => x.tariffcategoryid,
                    principalTable: "TariffCategory",
                    principalColumn: "tariffcategoryid");
                table.ForeignKey(
                    name: "Tariff_tarifftypeid_fkey",
                    column: x => x.tarifftypeid,
                    principalTable: "TariffType",
                    principalColumn: "tarifftypeid");
            });

        migrationBuilder.CreateTable(
            name: "FitnessService",
            columns: table => new
            {
                serviceid = table.Column<string>(type: "text", nullable: false),
                roomid = table.Column<string>(type: "text", nullable: true),
                employeeid = table.Column<string>(type: "text", nullable: true),
                duration = table.Column<string>(type: "text", nullable: true),
                cost = table.Column<decimal>(type: "numeric", nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("FitnessService_pkey", x => x.serviceid);
                table.ForeignKey(
                    name: "FitnessService_roomid_fkey",
                    column: x => x.roomid,
                    principalTable: "GymRoom",
                    principalColumn: "roomid");
                table.ForeignKey(
                    name: "employeeid",
                    column: x => x.employeeid,
                    principalTable: "Employee",
                    principalColumn: "employeeId");
            });

        migrationBuilder.CreateTable(
            name: "TrainingSession",
            columns: table => new
            {
                trainingid = table.Column<string>(type: "text", nullable: false),
                roomid = table.Column<string>(type: "text", nullable: true),
                employeeid = table.Column<string>(name: "employeeid ", type: "text", nullable: false),
                numberofparticipants = table.Column<int>(type: "integer", nullable: true),
                starttime = table.Column<DateTimeOffset>(type: "time with time zone", nullable: true),
                endtime = table.Column<DateTimeOffset>(type: "time with time zone", nullable: true),
                description = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("TrainingSession_pkey", x => x.trainingid);
                table.ForeignKey(
                    name: "TrainingSession_employeeid _fkey",
                    column: x => x.employeeid,
                    principalTable: "Employee",
                    principalColumn: "employeeId");
                table.ForeignKey(
                    name: "TrainingSession_roomid_fkey",
                    column: x => x.roomid,
                    principalTable: "GymRoom",
                    principalColumn: "roomid");
            });

        migrationBuilder.CreateTable(
            name: "Subscription",
            columns: table => new
            {
                subscriptionid = table.Column<string>(type: "text", nullable: false),
                price = table.Column<decimal>(type: "numeric", nullable: true),
                startdate = table.Column<DateOnly>(type: "date", nullable: true),
                duration = table.Column<string>(type: "text", nullable: true),
                isactive = table.Column<bool>(type: "boolean", nullable: true),
                clientid = table.Column<string>(type: "text", nullable: true),
                tariffid = table.Column<string>(type: "text", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("Subscription_pkey", x => x.subscriptionid);
                table.ForeignKey(
                    name: "Subscription_clientid_fkey",
                    column: x => x.clientid,
                    principalTable: "Client",
                    principalColumn: "clientid");
                table.ForeignKey(
                    name: "Subscription_tariffid_fkey",
                    column: x => x.tariffid,
                    principalTable: "Tariff",
                    principalColumn: "tariffid");
            });

        migrationBuilder.CreateTable(
            name: "TrainingRegistration",
            columns: table => new
            {
                registrationid = table.Column<string>(type: "text", nullable: false),
                trainingid = table.Column<string>(type: "text", nullable: true),
                clientid = table.Column<string>(type: "text", nullable: true),
                registrationdate = table.Column<DateOnly>(type: "date", nullable: true),
                isconfirmed = table.Column<bool>(type: "boolean", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("TrainingRegistration_pkey", x => x.registrationid);
                table.ForeignKey(
                    name: "TrainingRegistration_clientid_fkey",
                    column: x => x.clientid,
                    principalTable: "Client",
                    principalColumn: "clientid");
                table.ForeignKey(
                    name: "TrainingRegistration_trainingid_fkey",
                    column: x => x.trainingid,
                    principalTable: "TrainingSession",
                    principalColumn: "trainingid");
            });

        migrationBuilder.CreateIndex(
            name: "IX_FitnessService_employeeid",
            table: "FitnessService",
            column: "employeeid");

        migrationBuilder.CreateIndex(
            name: "IX_FitnessService_roomid",
            table: "FitnessService",
            column: "roomid");

        migrationBuilder.CreateIndex(
            name: "IX_GymRoom_branchid",
            table: "GymRoom",
            column: "branchid");

        migrationBuilder.CreateIndex(
            name: "IX_Payment_clientid",
            table: "Payment",
            column: "clientid");

        migrationBuilder.CreateIndex(
            name: "IX_Subscription_clientid",
            table: "Subscription",
            column: "clientid");

        migrationBuilder.CreateIndex(
            name: "IX_Subscription_tariffid",
            table: "Subscription",
            column: "tariffid");

        migrationBuilder.CreateIndex(
            name: "IX_Tariff_tariffcategoryid",
            table: "Tariff",
            column: "tariffcategoryid");

        migrationBuilder.CreateIndex(
            name: "IX_Tariff_tarifftypeid",
            table: "Tariff",
            column: "tarifftypeid");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingRegistration_clientid",
            table: "TrainingRegistration",
            column: "clientid");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingRegistration_trainingid",
            table: "TrainingRegistration",
            column: "trainingid");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingSession_employeeid ",
            table: "TrainingSession",
            column: "employeeid ");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingSession_roomid",
            table: "TrainingSession",
            column: "roomid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FitnessService");

        migrationBuilder.DropTable(
            name: "Payment");

        migrationBuilder.DropTable(
            name: "Subscription");

        migrationBuilder.DropTable(
            name: "TrainingRegistration");

        migrationBuilder.DropTable(
            name: "Tariff");

        migrationBuilder.DropTable(
            name: "Client");

        migrationBuilder.DropTable(
            name: "TrainingSession");

        migrationBuilder.DropTable(
            name: "TariffCategory");

        migrationBuilder.DropTable(
            name: "TariffType");

        migrationBuilder.DropTable(
            name: "Employee");

        migrationBuilder.DropTable(
            name: "GymRoom");

        migrationBuilder.DropTable(
            name: "Branch");
    }
}
