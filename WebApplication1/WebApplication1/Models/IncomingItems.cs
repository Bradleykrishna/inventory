using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class IncomingItems
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [DisplayName("Type of item")]
        public string ItemType { get; set; }

        [Required]
        [DisplayName("Name of Item")]
        public string ItemName { get; set; }

        [Required]
        [DisplayName("Descritpion")]
        public string ItemDescription { get; set; }

        [Required]
        [DisplayName("Amount")]
        public string ItemAmount { get; set; }

        [Required]
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}