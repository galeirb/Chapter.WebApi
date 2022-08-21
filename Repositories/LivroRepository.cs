using Chapter.WebApi.Contexts;
using Chapter.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
namespace Chapter.WebApi.Repositories
{
    public class LivroRepository
    {
        // possui acesso aos dados
        private readonly ChapterContext _context;
        // somente um data context na memória da aplicação na requisição, evitar o usar o new
        // para o repositório existir, precisa do contexto, a aplicacao cria
        // configurar no startup
        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }
        // retorna a lista de livros
        public List<Livro> Listar()
        {
           
            return _context.Livros.ToList();
        }
        public void Cadastrar(Livro livro)
        {
                            
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }
        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        // atualizar as informacoes de um livro, a partir da busca de livro por id
        public void Atualizar(int id, Livro livro)
        {
            // Busca o livro por id
            Livro livroBuscado = _context.Livros.Find(id);
            // caso encontre o livro, atualiza as informacoes
            if (livroBuscado != null)
            {
                // Atribui os novos valores
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }
            // UPDATE Livros SET Titulo = @Titulo, 
            // QuantidadePaginas = @QuantidadePaginas,
            // Disponivel = @Disponivel
            // WHERE Id = @IdRecebido;
            // Adiciona o livro atualizado
            _context.Livros.Update(livroBuscado);
            // Salva (persistir) as informações para serem gravadas no banco de dados
            _context.SaveChanges();
        }

               
        public void Deletar(int id)
        {
            // Busca um livro através do seu id
            Livro livroBuscado = _context.Livros.Find(id);
            // Remove o livro que foi buscado
            _context.Livros.Remove(livroBuscado);
            // Salva as alterações
            _context.SaveChanges();
        }


    }
}
