using RESThomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESThomework.Controllers
{
    public class AuthorsController : ApiController
    {
        // GET: api/Authors
        public IHttpActionResult Get()
        {
            var authors = AuthorsHelper.GetAllAuthors();
            return Ok(authors);
        }

        // GET: api/Authors/5
        public IHttpActionResult Get(int id)
        {
            var author = AuthorsHelper.GetById(id);

            if (author != null)
            {
                return Ok(author);
            }

            return Content(HttpStatusCode.NotFound, $"Author with id {id} not found");
        }


        //GET: api/Authors/5/articles
        [Route("api/Authors/{id}/articles")]
        public IHttpActionResult GetArticles(int id,string title= "",string level = "",string date="")
        {
            var articles = AuthorsHelper.GetArticlesByAuthor(id);

            if (!string.IsNullOrEmpty(title))
            {
                articles = AuthorsHelper.GetArticlesWithProps(id, title,level,date);
            }
            if (!string.IsNullOrEmpty(level))
            {
                articles = AuthorsHelper.GetArticlesWithProps(id,title ,level,date);
            }
            if (!string.IsNullOrEmpty(date))
            {
                articles = AuthorsHelper.GetArticlesWithProps(id, title, level,date);
            }
            return Ok(articles);

        }


        //[Route("api/{authorId}/articles")]  with manually entered ID 
        //public IHttpActionResult PostArticle(int authorId,Article article)
        //{
        //    if (!(Request.Headers.Contains("Authorization") && Request.Headers.Authorization.Scheme.Equals("admin")))
        //    {
        //        return Unauthorized();
        //    }

        //        AuthorsHelper.AddNewArticle(authorId, article);
        //        return Created("api/authors",article);

        //}

   
        [Route("api/{authorId}/articles")]
        public IHttpActionResult PostArticle(int authorId, [FromBody] Article article)
        {
            if (!(Request.Headers.Contains("Authorization") && Request.Headers.Authorization.Scheme.Equals("admin")))
            {
                return Unauthorized();
            }

            AuthorsHelper.AddNewArticle(authorId, article);
            return Created("api/authors", article);

        }
  
     
        public IHttpActionResult PostAuthor([FromBody] Author author)
        {
            if (!(Request.Headers.Contains("Authorization") && Request.Headers.Authorization.Scheme.Equals("admin")))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid && author != null)
            {
                try
                {
                    AuthorsHelper.AddNew(author);
                    return Created("api/authors", author);
                }
                catch
                {
                    return InternalServerError();
                }
            }

            return Content(HttpStatusCode.BadRequest, ModelState);
        }


        // PUT: api/Authors/5
        public IHttpActionResult PutAuthor(int id, Author employee)
        {
            AuthorsHelper.Update(employee);

            return StatusCode(HttpStatusCode.Created);
        }

       
        [Route("api/{authorId}/article/{articleId}")]
        public IHttpActionResult PutArticle(int authorId,string articleId,Article article)
        {
            AuthorsHelper.UpdateArticle(authorId,articleId,article);

            return StatusCode(HttpStatusCode.Created);
        }


    }
}
