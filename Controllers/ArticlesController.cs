using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NewsDesk.Data;
using System.Collections.Generic;
using NewsDesk.Models;
using NewsDesk.Messages;
using System;
using NewsDesk.Context;
using Microsoft.EntityFrameworkCore;

namespace NewsDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ArticleRepository _articles;

        public ArticlesController(IMapper mapper, DatabaseContext databaseContext) 
        {
            _mapper = mapper;
            _articles = new ArticleRepository(databaseContext);
        }

        [HttpGet]
        public ItemsWrapper GetAllArticles()
        {
            return new ItemsWrapper { Items = _mapper.Map<List<ArticleListView>>(_articles.GetAll()) };
        }


        [HttpGet("{id}")]
        public ArticleDetailView GetArticle(int id)
        {
            return _mapper.Map<ArticleDetailView>(_articles.Find(id));
        }

        [HttpPost]
        public ArticleDetailView CreateArticle([FromForm, FromBody] NewArticleCommand newArticleCommand)
        {
            var newArticle = new Article
            {
                Title = newArticleCommand.Title,
                Body = newArticleCommand.Body,
                PublishedDate = DateTime.Now,
                Category = newArticleCommand.Category,
                Author = newArticleCommand.Author
            };
            _articles.Add(newArticle);
            return _mapper.Map<ArticleDetailView>(newArticle);
        }

        [HttpPut("{id}")]
        public ArticleDetailView UpdateArticle([FromForm, FromBody] NewArticleCommand newArticleCommand, int id)
        {
            var updatedArticle = _mapper.Map<Article>(newArticleCommand);
            updatedArticle.Id = id;
            updatedArticle.PublishedDate=DateTime.Now;
            return _mapper.Map<ArticleDetailView>(_articles.Update(updatedArticle));
        }

        [HttpDelete("{id}")]
        public string DeleteArticle(int id)
        {
            _articles.Remove(id);
            return "Article Deleted";
        }

    }
}
