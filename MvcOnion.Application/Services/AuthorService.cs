using MvcOnion.Application.Dtos.AuthorDtos;
using MvcOnion.Application.IServices;
using MvcOnion.Domain.Entities;
using MvcOnion.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<bool> AuthorCreate(AuthorCreateDto authorCreateDto)
        {
            
            

            Author author = new Author
            {
                FirstName = authorCreateDto.FirstName,
                LastName = authorCreateDto.LastName,
                CreateDate = authorCreateDto.CreateDate,
                IsActive = authorCreateDto.IsActive,
            };

            return await authorRepository.Create(author);
        }

        public async Task<bool> AuthorDelete(int authorId)
        {
            Author author = await authorRepository.GetById(authorId);

           return await authorRepository.Delete(author);
        }

        public async Task<IEnumerable<AuthorListDto>> AuthorList(Expression<Func<Author, bool>> filter = null)
        {
           List<Author> authorList = authorRepository.GetFilteredAll(filter).Result.ToList();
            List<AuthorListDto> authorListDtos = authorList.Select( x => new AuthorListDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,

            }).ToList();
            return authorListDtos;
        }
            

        public async Task<bool> AuthorUpdate(AuthorUpdateDto authorUpdateDto)
        {
            Author author = await authorRepository.GetById(authorUpdateDto.Id);

            author.UpdateDate = authorUpdateDto.UpdateDate;
            author.FirstName = authorUpdateDto.FirstName;
            author.LastName = authorUpdateDto.LastName;

            return await authorRepository.Update(author);
        }

        public async Task<AuthorCreateDto> GetByAuthorId(int authorId)
        {
            Author author = await authorRepository.GetById(authorId);

            AuthorCreateDto authorCreateDto = new AuthorCreateDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
            return authorCreateDto;

        }

        public async Task<int> GetIdAuthorNameAndLastName(string authorName, string lastName)
        {
            return await authorRepository.GetIdByNameAndLastName(lastName, authorName);   
        }
    }
}
