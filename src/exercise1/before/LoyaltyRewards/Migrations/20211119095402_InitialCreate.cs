using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoyaltyRewards.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfActiveOffers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "OfferTypes",
                columns: table => new
                {
                    OfferTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysValid = table.Column<int>(type: "int", nullable: false),
                    ExpirationType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTypes", x => x.OfferTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateExpiring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MemberAssignedMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Members_MemberAssignedMemberId",
                        column: x => x.MemberAssignedMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MemberAssignedMemberId",
                table: "Offers",
                column: "MemberAssignedMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "OfferTypes");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
