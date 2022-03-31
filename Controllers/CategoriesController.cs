using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsDesk.Context;
using NewsDesk.Data;
using NewsDesk.Messages;
using System.Collections.Generic;

namespace NewsDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CategoriesRepository _categories;

        public CategoriesController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _categories = new CategoriesRepository(databaseContext);
        }

        [HttpGet]
        public List<CategoryListView> GetAllAuthors()
        {
            return _mapper.Map<List<CategoryListView>>(_categories.GetAll());
        }

        [HttpGet("{id}")]
        public CategoryListView GetAuthor(int id)
        {
            return _mapper.Map<CategoryDetailView>(_categories.Find(id));
        }
    }
}
