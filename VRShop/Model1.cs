namespace VRShop
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Model1 : DbContext
    {
        // Контекст настроен для использования строки подключения "Model1" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "VRShop.Model1" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model1" 
        // в файле конфигурации приложения.
        public Model1()
            : base("name=Model1")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserData> UsersData { get; set; }

        public virtual DbSet<ManagerData> ManagerData { get; set; }


        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
    }

    public class User
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public virtual UserData UserData { get; set; }
        public virtual ManagerData ManagerData { get; set; }
    }

    public class UserData
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        [Key]
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class ManagerData
    {
        public int Id { get; set; }
        [Key]
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string BeginningDateOfWork { get; set; }
    }




    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

       // public int? ParentCategory { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
            {
            Products = new List<Product>();
            }

    }

    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescripton { get; set; }

        public double Price { get; set; }

        public byte[] ProductImg { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }


    }

    public class OrderedProduct
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int? ProductId { get; set; }
        public string ProductName { get; set; }

        public int ProductQty { get; set; }

        public double Price { get; set; }
        public double Sum { get; set; }
        public int? UserId { get; set; }

        public string Date { get; set; }

        public bool OrderConfirmed { get; set; }

    }
}