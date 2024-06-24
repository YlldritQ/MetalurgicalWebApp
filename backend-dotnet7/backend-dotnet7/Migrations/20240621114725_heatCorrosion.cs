using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet7.Migrations
{
    /// <inheritdoc />
    public partial class heatCorrosion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corrosions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrosionRate = table.Column<int>(type: "int", nullable: false),
                    ProtectiveCoating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corrosions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeatTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrosionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeatTreatments_Corrosions_CorrosionId",
                        column: x => x.CorrosionId,
                        principalTable: "Corrosions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeatTreatments_CorrosionId",
                table: "HeatTreatments",
                column: "CorrosionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeatTreatments");

            migrationBuilder.DropTable(
                name: "Corrosions");
        }
    }
}
