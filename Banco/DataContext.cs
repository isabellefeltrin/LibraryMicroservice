using Book.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryMicroservice.Banco

{
    public class DataContext : DbContext
    {
                public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<BookModel> BookModel { get; set; }
}
}
