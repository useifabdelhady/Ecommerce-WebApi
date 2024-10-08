﻿using Ecommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Repository.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder.Ignore(e => e.TwoFactorEnabled);
        builder.Ignore(e => e.PhoneNumber);
        builder.Ignore(e => e.PhoneNumberConfirmed);
    }
}
