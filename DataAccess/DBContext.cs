namespace DataAccess
{
    using System.Data.Entity;

    public class DBContext : DbContext
    { 

        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatagory> Catagories { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<BuyerAddress> BuyerAddresses { get; set; }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerAddress> SellerAddresses { get; set; }

        public DbSet<EmployeeLogin> EmployeeLogins { get; set; }
        public DbSet<BuyerLogin> BuyerLogins { get; set; }
        public DbSet<SellerLogin> SellerLogins { get; set; }

        public DbSet<BuyerApproval> BuyerApprovals { get; set; }
        public DbSet<SellerApproval> SellerApprovals { get; set; }
        public DbSet<EmployeeApproval> EmployeeApprovals { get; set; }
        public DbSet<ProductApproval> ProductApprovals { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Mama> Mamas { get; set; }
        public DbSet<WorkingArea> WorkingAreas { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}