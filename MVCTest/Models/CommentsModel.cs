using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class CommentsModel
    {
        public int CommentId { get; set; }

        public string Comment { get; set; }
        public string Username { get; set; }

        public int ProductId { get; set; }

        public DateTime CommentedDate { get; set; }
    }
}
