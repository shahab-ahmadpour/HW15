using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Fee)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Date)
               .IsRequired();

        builder.HasOne(t => t.SourceCard)
               .WithMany()
               .HasForeignKey(t => t.SourceCardId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.DestinationCard)
               .WithMany()
               .HasForeignKey(t => t.DestinationCardId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
