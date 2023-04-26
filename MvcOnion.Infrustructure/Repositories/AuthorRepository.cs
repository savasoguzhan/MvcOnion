using MvcOnion.Domain.Entities;
using MvcOnion.Domain.IRepositories;
using MvcOnion.Infrustructure.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Infrustructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author, ApplicationDbContext>, IAuthorRepository
    {
        private readonly ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> GetIdByNameAndLastName(string name, string lastName)
        {
            Author author =  context.Set<Author>().FirstOrDefault( x => x.LastName == lastName);

            return author != null ? author.Id : 0;
        }
    }
}
