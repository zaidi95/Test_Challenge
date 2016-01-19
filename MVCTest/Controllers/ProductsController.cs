using MVCTest.Helper;
using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var modellst = ProductsHelper.GetProductsfromMemory();
            return View(modellst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductsModel model)
        {
            ProductsHelper.CreateProducts(model);
            ModelState.Clear();
            ViewBag.Message = "Products has been added successfully";
            return View();
        }


        public ActionResult ProductDetails(int productId)
        {
            var model = ProductsHelper.GetProduct(productId);
            ViewBag.ProductId = productId;
            return View(model);
        }

        public ActionResult Comments(int productId)
        {
            List<CommentsModel> commentslst = CommentsHelper.GetCommentsFromMemory(productId);
            return PartialView("Comments", commentslst);

        }

        public ActionResult PostComment(int productId, string commentText)
        {
            var entity = new CommentsModel { Comment = commentText, ProductId = productId };
            var commentslst = CommentsHelper.AddComment(entity);
            return PartialView("Comments", commentslst);
        }
    }
}