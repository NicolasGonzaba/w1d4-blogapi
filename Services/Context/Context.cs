using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using w1d4_blogapi.Models;

namespace w1d4_blogapi.Services.Context;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {

    }

    public DbSet<UserModel> UserInfo { get; set; }
    public DbSet<BlogItemModel> BlogInfo { get; set; }
}
