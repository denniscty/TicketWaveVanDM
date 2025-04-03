using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketWave.Data.Migrations
{
    /// <inheritdoc />
    public partial class CU1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventListing",
                columns: table => new
                {
                    EventListingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    TicketQuant = table.Column<int>(type: "int", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    BuyerID = table.Column<int>(type: "int", nullable: false),
                    OfferAccepted = table.Column<bool>(type: "bit", nullable: false),
                    FileUploads = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventListing", x => x.EventListingID);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSellerID = table.Column<int>(type: "int", nullable: false),
                    UserBuyerID = table.Column<int>(type: "int", nullable: false),
                    EventListingID = table.Column<int>(type: "int", nullable: false),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_EventListing_EventListingID",
                        column: x => x.EventListingID,
                        principalTable: "EventListing",
                        principalColumn: "EventListingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_EventListingID",
                table: "Review",
                column: "EventListingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "EventListing");
        }
    }
}
