using Domain;
using Domain._Contracts;
using Domain._Contracts.Response;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryImplementation : IRepository
    {
        private readonly RepositoryDbContext _context;

        public RepositoryImplementation(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Usuario entity)
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Existe(string login)
        {
            return await _context.Usuarios.AnyAsync(x => x.Login == login);
        }

        public async Task<UsuarioResponse> Obter(string login, string senha)
        {
            var dados = await _context.Usuarios
                .SingleOrDefaultAsync(x => x.Login == login
                && x.Password == senha);

            if (dados == null)
                return null;

            return new UsuarioResponse
            {
                ChaveUsuario = dados.Chave
            };
        }
    }
}
