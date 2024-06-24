using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet7.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        IF OBJECT_ID('FK_Materials_Suppliers_SupplierId', 'F') IS NOT NULL
        BEGIN
            ALTER TABLE Materials DROP CONSTRAINT FK_Materials_Suppliers_SupplierId;
        END");

            // Check if the SupplierId column exists
            migrationBuilder.Sql(@"
        IF COL_LENGTH('Materials', 'SupplierId') IS NULL
        BEGIN
            ALTER TABLE Materials ADD SupplierId int NOT NULL DEFAULT 0;
        END");

            // Ensure an index on SupplierId
            migrationBuilder.Sql(@"
        IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Materials_SupplierId' AND object_id = OBJECT_ID('Materials'))
        BEGIN
            CREATE INDEX IX_Materials_SupplierId ON Materials (SupplierId);
        END");

            // Add foreign key constraint
            migrationBuilder.Sql(@"
        IF OBJECT_ID('FK_Materials_Suppliers_SupplierId', 'F') IS NULL
        BEGIN
            ALTER TABLE Materials ADD CONSTRAINT FK_Materials_Suppliers_SupplierId FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id) ON DELETE CASCADE;
        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        IF OBJECT_ID('FK_Materials_Suppliers_SupplierId', 'F') IS NOT NULL
        BEGIN
            ALTER TABLE Materials DROP CONSTRAINT FK_Materials_Suppliers_SupplierId;
        END");

            // Drop the index if it exists
            migrationBuilder.Sql(@"
        IF EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Materials_SupplierId' AND object_id = OBJECT_ID('Materials'))
        BEGIN
            DROP INDEX IX_Materials_SupplierId ON Materials;
        END");

            // Drop the column if it exists
            migrationBuilder.Sql(@"
        IF COL_LENGTH('Materials', 'SupplierId') IS NOT NULL
        BEGIN
            ALTER TABLE Materials DROP COLUMN SupplierId;
        END");
        }
    }
}
