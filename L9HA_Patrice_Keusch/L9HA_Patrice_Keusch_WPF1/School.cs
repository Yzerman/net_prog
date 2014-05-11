namespace L9HA_Patrice_Keusch_WPF1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class School : DbContext
    {
        public School()
            : base("name=School")
        {
        }

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
