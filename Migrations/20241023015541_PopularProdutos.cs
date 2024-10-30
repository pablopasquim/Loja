using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome, Descricao,Preco, ImamgemUrl, Estoque, DataCadastro, CategoriaId) " +
                    "Values('Coca-Cola', 'Coca-Cola 600ml', 6.00, 'coca.jpg', 10, now(), 3)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delte from Produtos");
        }
    }
}
