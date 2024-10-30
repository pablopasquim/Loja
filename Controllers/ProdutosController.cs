using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos.ToList();
                if (produtos is null || produtos.Count == 0)
                {
                    return NotFound("Nenhum produto encontrado.");
                }
                return produtos;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado.");
                }
                return produto;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return BadRequest("Dados inválidos.");
                }

                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return CreatedAtRoute("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar o produto: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest("Id do produto não corresponde.");
                }

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok("Produto atualizado com sucesso.");
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound("Produto não encontrado para atualização.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o produto: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if (produto is null)
                {
                    return NotFound("Produto não encontrado.");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok("Produto removido com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover o produto: {ex.Message}");
            }
        }
    }
}
