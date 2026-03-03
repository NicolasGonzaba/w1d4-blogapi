using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using w1d4_blogapi.Models;

namespace w1d4_blogapi.Services.Context;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<UserModel> UserInfo { get; set; }
    
    public DbSet<BlogItemModel> BlogInfo { get; set; }
}
