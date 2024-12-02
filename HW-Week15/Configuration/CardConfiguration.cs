using HW_Week15.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CardNumber)
               .IsRequired()
               .HasMaxLength(16);

        builder.Property(c => c.Balance)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(c => c.Password)
               .IsRequired()
               .HasMaxLength(50);
    }
}
