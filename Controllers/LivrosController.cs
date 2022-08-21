using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
   
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]

public class LivrosController : ControllerBase
    {
        
private readonly LivroRepository _livroRepository;
        public LivrosController(LivroRepository
        livroRepository)
        {
            _livroRepository = livroRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            
            return Ok(_livroRepository.Listar());
        }

        // POST /api/livros
        [HttpPost]
        
        public IActionResult Cadastrar(Livro livro)
        {
            _livroRepository.Cadastrar(livro);
            return StatusCode(201);
        }

        [HttpGet("{id}")] 
// busca um livro a partir do id passado na requisição GET /api/livros/1
        public IActionResult BuscarPorId(int id)
        {
            // busca o livro por id no banco
            Livro livro = _livroRepository.BuscarPorId(id);
            // se o livro não for encontrado, retorna uma status 
            // de não encontrado, 404 (NotFound).
            if (livro == null)
            {
                return NotFound();
            }
            // caso tenha sido encontrado, retorna o status 
            // de sucesso com a informação sobre o livro
            return Ok(livro);
        }

        // PUT /api/livros/{id}
        [HttpPut("{id}")] // o id passado no PUT /api/livros/1
                          // recebe a informacao do livro que deseja 
                          // atualizar no corpo da requisição
        public IActionResult Atualizar(int id, Livro livro)
        {
            // atualizar as informações de um livro 
            // no corpo da requisição, corresponde as novas informações do livro
            // na solicitação, o id do livro a ser atualizado _livroRepository.Atualizar(id, livro);
            _livroRepository.Atualizar(id, livro);
            return StatusCode(204);
        }

        // DELETE /api/livros/{id}       
        [HttpDelete("{id}")] // o id passado no DELETE /api/livros/1
        public IActionResult Deletar(int id)
        {
            _livroRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
