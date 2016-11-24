using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public void Add(Blog blog)
        {
            _blogRepository.Add(blog);
            _blogRepository.Commit();
        }

        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
            _blogRepository.Commit();
        }

        public void Delete(Blog blog)
        {
            _blogRepository.Delete(blog);
            _blogRepository.Commit();
        }

        public Blog GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        public Blog[] GetAll()
        {
            return _blogRepository.GetAll().ToArray();
        }
    }
}
