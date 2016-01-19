using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class ProductsModel
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public double Price { get; set; }

        public List<CommentsModel> Comments { get; set; }
    }
}