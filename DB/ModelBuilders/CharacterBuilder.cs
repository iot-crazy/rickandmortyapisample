using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.ModelBuilders
{
    static class CharacterBuilder
    {
        public static ModelBuilder BuildCharacter(this ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Characters").HasKey(e => e.ID);

                /* Properties */
                entity.Property(e => e.ID).ValueGeneratedNever();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Status);
                entity.Property(e => e.Type);
                entity.Property(e => e.Gender);
                entity.Property(e => e.Image);
                entity.Property(e => e.Created);
                entity.Property(e => e.LocationName);
                entity.Property(e => e.LocationURL);
                entity.Property(e => e.OriginName);
                entity.Property(e => e.OriginURL);
            });
        }
    }
}
