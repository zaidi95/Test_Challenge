using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Helper
{
    public class CommentsHelper
    {
        static List<CommentsModel> CommentsList = new List<CommentsModel>();

        public static List<CommentsModel> GetCommentsFromMemory(int productId)
        {
            if (SessionHelper.GetSession("Comments").ToString() == string.Empty)
            {
                SetDefaultComments();
            }
            return (SessionHelper.GetSession("Comments") as List<CommentsModel>).Where(a => a.ProductId == productId).ToList();
        }

        private static void SetDefaultComments()
        {
            CommentsList.Add(new CommentsModel { CommentId = 1, Username = "abc", Comment = "its a good product", ProductId = 1, CommentedDate = DateTime.Now.AddDays(-2) });
            CommentsList.Add(new CommentsModel { CommentId = 2, Username = "xyz", Comment = "good", ProductId = 1, CommentedDate = DateTime.Now.AddDays(-1) });
            CommentsList.Add(new CommentsModel { CommentId = 3, Username = "cba", Comment = "awesome", ProductId = 1, CommentedDate = DateTime.Now.AddDays(-1) });

            CommentsList.Add(new CommentsModel { CommentId = 4, Username = "abc", Comment = "its a good product", ProductId = 2, CommentedDate = DateTime.Now.AddDays(-2) });
            CommentsList.Add(new CommentsModel { CommentId = 5, Username = "xyz", Comment = "good", ProductId = 2, CommentedDate = DateTime.Now.AddDays(-1) });
            CommentsList.Add(new CommentsModel { CommentId = 6, Username = "cba", Comment = "awesome", ProductId = 2, CommentedDate = DateTime.Now.AddDays(-1) });

            CommentsList.Add(new CommentsModel { CommentId = 7, Username = "abc", Comment = "its a good product", ProductId = 3, CommentedDate = DateTime.Now.AddDays(-2) });
            CommentsList.Add(new CommentsModel { CommentId = 8, Username = "xyz", Comment = "good", ProductId = 3, CommentedDate = DateTime.Now.AddDays(-1) });
            CommentsList.Add(new CommentsModel { CommentId = 9, Username = "cba", Comment = "awesome", ProductId = 3, CommentedDate = DateTime.Now.AddDays(-1) });
            CommentsList.Add(new CommentsModel { CommentId = 10, Username = "abc", Comment = "its a good product", ProductId = 4, CommentedDate = DateTime.Now.AddDays(-2) });
            CommentsList.Add(new CommentsModel { CommentId = 11, Username = "xyz", Comment = "good", ProductId = 4, CommentedDate = DateTime.Now.AddDays(-1) });
            CommentsList.Add(new CommentsModel { CommentId = 12, Username = "cba", Comment = "awesome", ProductId = 4, CommentedDate = DateTime.Now.AddDays(-1) });

            SessionHelper.SetSession("Comments", CommentsList);
        }
        public static List<CommentsModel> AddComment(CommentsModel entity)
        {

            var commentId = CommentsList.Max(a => a.CommentId) + 1;
            CommentsList.Add(new CommentsModel { CommentId = commentId, Comment = entity.Comment, ProductId = entity.ProductId, Username = Environment.MachineName, CommentedDate = DateTime.Now });
            SessionHelper.SetSession("Comments", CommentsList);
            return (SessionHelper.GetSession("Comments") as List<CommentsModel>).Where(a => a.ProductId == entity.ProductId).ToList();
        }



    }
}