using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShopApi.Models
{
    public class Product
    {
        [Key]
        public string SKU { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [MaxLength(150)]
        public string Description { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
