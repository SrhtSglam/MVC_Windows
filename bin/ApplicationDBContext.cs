using Microsoft.EntityFrameworkCore;
using MVC_Windows.Models;

namespace MVC_Windows.Data {
    public class ApplicationDBContext : DbContext{
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){

        }

        public DbSet<CustomerModel> customerModel { get; set; }

    }
}