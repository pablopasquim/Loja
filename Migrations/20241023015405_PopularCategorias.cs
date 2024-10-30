using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas', 'bebidas.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Salgadinhos', 'salgadinhos.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Frutas', 'frutas.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Lanches', 'lanches.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
