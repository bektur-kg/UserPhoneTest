﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Infrastructure.Modules.Phones;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.HasOne(p => p.User)
            .WithMany(u => u.Phones)
            .HasForeignKey(p => p.UserId);

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasAnnotation("Regex", PhoneAttributeConstants.InternationalPhoneRegex);
    }
}
