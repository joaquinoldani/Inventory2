using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class StorageEntity
    {
        [Key]
        [StringLength(50)]
        public string StorageId { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int PartialQuantity { get; set; }

        // Asi armo una ForeingKey al Id de Productos
        public string ProductId { get; set; }
        public ProductEntity Product { get; set; }

        // Asi armo una ForeingKey al Id de Deposito
        public string WarehouseId { get; set; }
        public WarehouseEntity Warehouse { get; set; }

        // Por la relacion 1:N con EntradaSalida
        public ICollection<InputOutputEntity> InputOutputs { get; set; }
    }
}
