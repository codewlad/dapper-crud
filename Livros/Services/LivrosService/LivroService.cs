using Dapper;
using Livros.Models;
using System.Data.SqlClient;

namespace Livros.Services.LivrosService
{
    public class LivroService : ILivroInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string? getConnection;
        public LivroService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Livro>> CreateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "insert into Livros(titulo, autor) values (@titulo,@autor)";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livro>("select * from livros");
            }
        }

        public async Task<IEnumerable<Livro>> DeleteLivro(int livroId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "delete from Livros where id = @Id";
                await con.ExecuteAsync(sql, new { Id = livroId });

                return await con.QueryAsync<Livro>("select * from livros");
            }
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros";
                return await con.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> GetLivroById(int livroId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros where id = @Id";
                return await con.QueryFirstOrDefaultAsync<Livro>(sql, new { Id = livroId });
            }
        }

        public async Task<IEnumerable<Livro>> UpdateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "update Livros set titulo = @titulo, autor = @autor where id = @id";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livro>("select * from livros");
            }
        }
    }
}
