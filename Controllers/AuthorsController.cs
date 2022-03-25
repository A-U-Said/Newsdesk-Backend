using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsDesk.Context;
using NewsDesk.Data;
using NewsDesk.Messages;
using System.Collections.Generic;

namespace NewsDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private AuthorRepository _authors;

        public AuthorsController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _authors = new AuthorRepository(databaseContext);
        }

        [HttpGet]
        public List<AuthorListView> GetAllAuthors()
        {
            return _mapper.Map<List<AuthorListView>>(_authors.GetAll());
        }

        [HttpGet("{id}")]
        public AuthorDetailView GetAuthor(int id)
        {
            return _mapper.Map<AuthorDetailView>(_authors.Find(id));
        }

    }
}
