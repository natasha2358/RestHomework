using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RESThomework.Models
{
    public class Author 
    {
        //  "UserId": "2",
        //"Name": "Jane Dean",
        //"Username": "janedean",
        //"Email": "jane.d@gmail.com",
        
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public List<Article> Articles { get; set; }
    }
}