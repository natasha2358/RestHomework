﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESThomework.Models
{
    public class Article
    {
        
        public Article(string autoGeneratedId, string title, string date, string level)
        {
            this.Id = autoGeneratedId;
            this.Title = title;
           this.DatePublished = date;
            this.Level = level;
        }

        public string Id { get; set; }
        public string Title { get; set; }

        public string DatePublished { get; set; }

        public string Level { get; set; }
    }
}