using Books.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Books.Persistence.EntityConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasData(
                new Author()
                {
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    FirstName = "Stephen",
                    LastName = "King"
                },
                new Author()
                {
                    Id = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author()
                {
                    Id = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    FirstName = "Neil",
                    LastName = "Gaiman"
                },
                new Author()
                {
                    Id = new Guid("578359b7-1967-41d6-8b87-64ab7605587e"),
                    FirstName = "Tom",
                    LastName = "Lanoye"
                },
                new Author()
                {
                    Id = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                },
                new Author()
                {
                    Id = new Guid("a1da1d8e-1988-4634-b538-a01709477b77"),
                    FirstName = "Jens",
                    LastName = "Lapidus"
                });
        }
    }
}
