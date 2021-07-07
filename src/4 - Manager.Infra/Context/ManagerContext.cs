using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace  Manager.Infra.Context
{
    public class ManagerContext : DbContext{
        public ManagerContext()
        {
            
        }
        public ManagerContext(DbContextOptions<ManagerContext> options):base(options) 
        {}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        //     optionsBuilder.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=APIManagerUser;User Id=miche;Password=g5h4q1x8;Integrated Security=true;User Instance=true;");
        // }

        public virtual DbSet<User> Users{get; set;} 

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new UserMap());
        }
    }
}