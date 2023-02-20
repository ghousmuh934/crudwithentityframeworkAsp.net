using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudDBWithEntityFramework.Models
{
    [MetadataType(typeof(ProudctValidation))]
    public partial class Product
    {

    }
    public class ProudctValidation
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
    }
}