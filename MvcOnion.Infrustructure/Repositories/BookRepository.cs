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
    public class BookRepository : BaseRepository<Book, ApplicationDbContext> , IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
