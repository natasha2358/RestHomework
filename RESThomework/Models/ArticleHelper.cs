using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RESThomework.Models
{
    public class ArticleHelper
    {
        public static List<Article> GetAllArticles()
        {
            List<Article> articles = new List<Article>();

            using (StreamReader r = new StreamReader(GetFilePath()))
            {
                string json = r.ReadToEnd();
                articles = JsonConvert.DeserializeObject<List<Article>>(json);
            }

            return articles;
        }



        public static Article GetById(int id)
        {
            return GetAllArticles().FirstOrDefault(e => e.Id.Equals(id));
        }

        public static void AddNew(int authorId, Article article)
        {
            var filePath = GetFilePath();
            var author = AuthorsHelper.GetById(authorId);

            if (author != null)  // if the author exists
            {
                List<Article> articles = AuthorsHelper.GetArticlesByAuthor(authorId);

                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    //articles = JsonConvert.DeserializeObject<List<Article>>(json);
                    articles = AuthorsHelper.GetArticlesByAuthor(authorId);
                    articles.Add(article);
                }

                File.WriteAllText(filePath, JsonConvert.SerializeObject(articles));
            }
        }

        public static void Update(int authorId,Article article)
        {
            var filePath = GetFilePath();
            List<Article> articles;
           // Author author;
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                articles = JsonConvert.DeserializeObject<List<Article>>(json);
                articles = AuthorsHelper.GetArticlesByAuthor(authorId);
                articles.Where(e => e.Id == article.Id).Select(x => {
                    x.Title = article.Title;
                    x.DatePublished = article.DatePublished;
                    x.Level = article.Level;
                    return x;
                })
                    .ToList();
            }

            File.WriteAllText(filePath, JsonConvert.SerializeObject(articles));
        }

        public static void Delete(int id)
        {
            var filePath = GetFilePath();
            List<Article> employees;

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                employees = JsonConvert.DeserializeObject<List<Article>>(json);

                var employeeToRemove = employees.Single(e => e.Id.Equals(id));
                employees.Remove(employeeToRemove);
            }

            File.WriteAllText(filePath, JsonConvert.SerializeObject(employees));
        }

        private static string GetFilePath()
        {
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data", "Authors.json");
        }
    }
}