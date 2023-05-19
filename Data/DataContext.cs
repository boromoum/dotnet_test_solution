using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CMG.TestSolution.Api.Data
{
  public class DataContext : DbContext
  {

    // public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Character> Characters => Set<Character>();
  }
}