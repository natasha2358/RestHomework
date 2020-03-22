using RESThomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESThomework.Controllers
{
    public class ArticleController : ApiController
    {
        // GET: api/Article
        public IHttpActionResult Get()
        {
            var employees = ArticleHelper.GetAllArticles();
            return Ok(employees);
        }


        // POST: api/authorId/
        //public IHttpActionResult PostArticle(int authorId,Article article)
        //{

        //    if (!(Request.Headers.Contains("Authorization") && Request.Headers.Authorization.Scheme.Equals("admin")))
        //    {
        //        return Unauthorized();
        //    }
            
        //    if (ModelState.IsValid && article != null)
        //    {
        //        try
        //        {
        //            ArticleHelper.AddNew(authorId,article);
        //            return Created("api/authors", article);
        //        }
        //        catch
        //        {
        //            return InternalServerError();
        //        }
        //    }

        //    return Content(HttpStatusCode.BadRequest, ModelState);
        //}


        // PUT: api/Article/5
        public IHttpActionResult Put(int id,Article article)
        {
            if (!(Request.Headers.Contains("Authorization") && Request.Headers.Authorization.Scheme.Equals("admin")))
            {
                    ArticleHelper.Update(id,article);
                   return StatusCode(HttpStatusCode.OK);
            }
             return StatusCode(HttpStatusCode.Unauthorized);
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
        }
    }
}
