using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingWiki_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.Property(c => c.ISBN).HasMaxLength(50);
            modelBuilder.Property(c => c.ISBN).IsRequired();
            modelBuilder.HasKey(c => c.BookID);
            modelBuilder.Ignore(c => c.PriceRange);
            modelBuilder.HasOne(c => c.Publisher)
                .WithMany(c => c.Books)
                .HasForeignKey(c => c.Publisher_id);
            modelBuilder.Property(u => u.Price).HasPrecision(10, 5);
        }

    }
}
