﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Entity.Metadata;

namespace PersonalWebsite.Models
{
    public class DataDbContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }

        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var contentEntity = builder.Entity<Content>();
            contentEntity.Property(x => x.InternalCaption).IsRequired().HasMaxLength(255);
            contentEntity.HasKey(x => x.Id);
            contentEntity.HasMany(x => x.Translations).WithOne(x => x.Content).OnDelete(DeleteBehavior.Cascade);

            var translationEntity = builder.Entity<Translation>();
            translationEntity.HasKey(x => x.Id);
            translationEntity.HasIndex(x => new { x.Version, x.ContentId }).IsUnique();
            translationEntity.Property(x => x.ContentId).IsRequired();
            translationEntity.Property(x => x.State).IsRequired();
            translationEntity.Property(x => x.Version).IsRequired();
            translationEntity.Property(x => x.Version).HasMaxLength(10);
 
            translationEntity.Property(x => x.UpdatedAt).IsRequired();
            translationEntity.Property(x => x.Title).IsRequired();
            translationEntity.Property(x => x.ContentMarkup).IsRequired();
            translationEntity.Property(x => x.Description).IsRequired();
            translationEntity.Property(x => x.UrlName).IsRequired();
            translationEntity.Property(x => x.UrlName).HasMaxLength(200);
            translationEntity.HasIndex(x => new { x.Version, x.UrlName }).IsUnique();
        }
    }
}
