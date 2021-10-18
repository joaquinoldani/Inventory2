using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class CategoryEntity
    { 
        [Key]
        [StringLength(50)]
        public string CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        // Por la relacion 1:N con Productos
        public ICollection<ProductEntity> Products { get; set; }
    }
}
