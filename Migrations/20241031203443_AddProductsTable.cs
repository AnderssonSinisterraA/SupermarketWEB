using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketWEB.Migrations
{
    public partial class AddProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Verificar si la tabla 'Categories' ya existe antes de crearla
            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.Categories', 'U') IS NULL 
                BEGIN 
                    CREATE TABLE [Categories] (
                        [Id] int NOT NULL IDENTITY,
                        [Name] nvarchar(max) NOT NULL,
                        [Description] nvarchar(max) NULL,
                        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
                    ) 
                END
            ");

            // Renombrar la columna 'Stork' a 'Stock' en la tabla 'Products'
            migrationBuilder.RenameColumn(
                name: "Stork",
                table: "Products",
                newName: "Stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Renombrar la columna 'Stock' a 'Stork' en la tabla 'Products'
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "Stork");
        }
    }
}
