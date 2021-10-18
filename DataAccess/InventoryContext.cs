using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    /// <summary>
    /// Heredo de DbContext y hago la coneccion a la BD
    /// </summary>
    public class InventoryContext : DbContext
    {
        //DbSet busca en la BD lo que sea, pero antes tengo que hacer la referencia a la capa de Entidades
        //desde Dependencias. Ahora hago todas las relaciones con las tablas
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<InputOutputEntity> InOut { get; set; }

        public DbSet<WarehouseEntity> Warehouses { get; set; }

        public DbSet<StorageEntity> Storages { get; set; }

        // Configuro la BD sobreescribiendo el metodo OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // A lo mejor ya esta configurado, pero en en caso de que no
            if (!options.IsConfigured)
            {
                // En Dependencias, NuGet packages, instalar Microsoft.EntityFrameworkCore.SqlServer y Microsoft.EntityFrameworkCore.Tools
                // Server = nombre del PC, Database = le doy como quiero que se llame, User Id = el user del momento
                // y la Password = para desbloquear el PC, SOLO PARA REMOTO
                
                //options.UseSqlServer("Server=TS-SERVER\\DESARROLLO; Database=FakeDb; User Id=joaquin, Password=joaquin");

                // Para ahora que estoy local, la config es la siguiente
                options.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=InventoryDb; Trusted_Connection=True");

                // Ahora creo las migraciones con el siguiente comando en Consola del Administrador de Paquetes
                // add-migration NombreMigracion -s DataAccess
                // con “-s” indicamos que utilice el ensamblado DataAccess como Startup y asi no debemos estar cambiando en Visual Studio
                // nuestro proyecto de inicio cada vez que necesitemos crear una migración.

                // Ahora en Consola del Administrador de Paquetes corro las migraciones con
                // update-database -s DataAccess
                // Si no existe la BD, la crea, sino la actualiza
            }
        }

        // Reescribo este metodo voy a crear mis modelos en la BD con informacion fake para probar cosas
        // y no crear una BD vacia con los siguientes comandos
        // add-migration AddData
        // update-database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { CategoryId="ASH", CategoryName="Aseo Hogar"},
                new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
                new CategoryEntity { CategoryId = "HRG", CategoryName = "Hogar" },
                new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumeria" },
                new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
                new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
                );

            // para crear Ids unicos y autoincrementales tengo que usar Guid.NewGuid().ToString()
            modelBuilder.Entity<WarehouseEntity>().HasData(
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName="Bodega Central", WarehouseAddress="Calle 8 con 23"},
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Norte", WarehouseAddress = "Calle Norte con Occidente" }
                );
        }

        
    
    }
}
