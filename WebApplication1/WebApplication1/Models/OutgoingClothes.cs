using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OutgoingClothes
    {
        [Key]
        public int ClothesID { get; set; }

        [Required]
        [DisplayName("Type of clothing")]
        public string ClothingType { get; set; }

        [Required]
        [DisplayName("Amount of item")]
        public double ClothingAmount { get; set; }

        [Required]
        [DisplayName("Size of Item")]
        public string Size { get; set; }
    }
}