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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder) {
            modelBuilder.HasKey(c => c.Author_Id);
            modelBuilder.Property(c => c.FirstName).HasMaxLength(50);
            modelBuilder.Property(c => c.FirstName).IsRequired();
            modelBuilder.Property(c => c.LastName).IsRequired();
            modelBuilder.Ignore(c => c.FullName);


        }



    }
}
