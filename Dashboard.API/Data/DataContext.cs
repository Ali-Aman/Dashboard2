using Microsoft.EntityFrameworkCore;
using Dashboard.API.Models;

namespace Dashboard.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public  DbSet<User> Users {get; set;}
        public  DbSet<Patient> Patients {get; set;}    
        
    }
}