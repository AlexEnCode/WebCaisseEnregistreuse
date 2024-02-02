using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCaisseEnregistreuse.Migrations
{
    public partial class newmigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantiteStock = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Informatique" },
                    { 2, "Électronique" },
                    { 3, "Littérature" }
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "Categorie", "CategorieId", "Description", "ImageUrl", "Nom", "Prix", "QuantiteStock" },
                values: new object[,]
                {
                    { 1, "Informatique", null, "Ordinateur portable haute performance", "url_de_l_image1.jpg", "Ordinateur portable", 999.99m, 50 },
                    { 2, "Électronique", null, "Smartphone dernier cri", "url_de_l_image2.jpg", "Smartphone", 599.99m, 30 },
                    { 3, "Littérature", null, "Livre captivant", "url_de_l_image3.jpg", "Livre", 19.99m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieId",
                table: "Produits",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
