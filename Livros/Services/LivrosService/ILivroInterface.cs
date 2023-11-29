using Livros.Models;

namespace Livros.Services.LivrosService
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int livroId);
        Task<IEnumerable<Livro>> CreateLivro(Livro livro);
        Task<IEnumerable<Livro>> UpdateLivro(Livro livro);
        Task<IEnumerable<Livro>> DeleteLivro(int livroId);
    }
}
