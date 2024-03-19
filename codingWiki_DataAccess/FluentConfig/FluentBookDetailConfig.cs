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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            //...........BookDetail
            modelBuilder.ToTable("BookDetails_Fluent");
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Property(c => c.NumberOfChapters).IsRequired();
            modelBuilder.HasKey(c => c.BookDetail_Id);
            modelBuilder.HasOne(c => c.Book)
                .WithOne(c => c.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(c => c.Book_Id);
        }

    }
}
