using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AndreAirLines.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    District = table.Column<string>(type: "varchar(60)", nullable: true),
                    City = table.Column<string>(type: "varchar(60)", nullable: true),
                    Country = table.Column<string>(type: "varchar(60)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(15)", nullable: true),
                    Street = table.Column<string>(type: "varchar(60)", nullable: true),
                    State = table.Column<string>(type: "varchar(5)", nullable: true),
                    Number = table.Column<string>(type: "varchar(20)", nullable: true),
                    Complement = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Acronym = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Acronym);
                    table.ForeignKey(
                        name: "FK_Airport_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Sex = table.Column<char>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Passenger_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasePrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationAcronym = table.Column<string>(type: "varchar(30)", nullable: true),
                    OriginAcronym = table.Column<string>(type: "varchar(30)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    PercentagePromotion = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasePrice_Airport_DestinationAcronym",
                        column: x => x.DestinationAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasePrice_Airport_OriginAcronym",
                        column: x => x.OriginAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasePrice_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationAcronym = table.Column<string>(type: "varchar(30)", nullable: true),
                    OriginAcronym = table.Column<string>(type: "varchar(30)", nullable: true),
                    AircraftId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisembarkationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_DestinationAcronym",
                        column: x => x.DestinationAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_OriginAcronym",
                        column: x => x.OriginAcronym,
                        principalTable: "Airport",
                        principalColumn: "Acronym",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PassengerCpf = table.Column<string>(type: "varchar(14)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Passenger_PassengerCpf",
                        column: x => x.PassengerCpf,
                        principalTable: "Passenger",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_AddressId",
                table: "Airport",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePrice_ClassId",
                table: "BasePrice",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePrice_DestinationAcronym",
                table: "BasePrice",
                column: "DestinationAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_BasePrice_OriginAcronym",
                table: "BasePrice",
                column: "OriginAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftId",
                table: "Flight",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationAcronym",
                table: "Flight",
                column: "DestinationAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OriginAcronym",
                table: "Flight",
                column: "OriginAcronym");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_AddressId",
                table: "Passenger",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClassId",
                table: "Ticket",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerCpf",
                table: "Ticket",
                column: "PassengerCpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasePrice");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
