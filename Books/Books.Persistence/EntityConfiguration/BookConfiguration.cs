﻿using Books.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Books.Persistence.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.Description)
                .HasMaxLength(2500);

            builder.HasData(
                new Book()
                {
                    Id = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                    AuthorId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Title = "The Shining",
                    Description =
                        "The Shining is a horror novel by American author Stephen King. Published in 1977, it is King's third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre. "
                },
                new Book()
                {
                    Id = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                    AuthorId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Title = "Misery",
                    Description =
                        "Misery is a 1987 psychological horror novel by Stephen King. This novel was nominated for the World Fantasy Award for Best Novel in 1988, and was later made into a Hollywood film and an off-Broadway play of the same name."
                },
                new Book()
                {
                    Id = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                    AuthorId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Title = "It",
                    Description =
                        "It is a 1986 horror novel by American author Stephen King. The story follows the exploits of seven children as they are terrorized by the eponymous being, which exploits the fears and phobias of its victims in order to disguise itself while hunting its prey. 'It' primarily appears in the form of a clown in order to attract its preferred prey of young children."
                },
                new Book()
                {
                    Id = new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                    AuthorId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Title = "The Stand",
                    Description =
                        "The Stand is a post-apocalyptic horror/fantasy novel by American author Stephen King. It expands upon the scenario of his earlier short story 'Night Surf' and outlines the total breakdown of society after the accidental release of a strain of influenza that had been modified for biological warfare causes an apocalyptic pandemic which kills off the majority of the world's human population."
                },
                new Book()
                {
                    Id = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                    AuthorId = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    Title = "A Game of Thrones",
                    Description =
                        "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin. It was first published on August 1, 1996."
                },
                new Book()
                {
                    Id = new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                    AuthorId = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    Title = "The Winds of Winter",
                    Description = "Forthcoming 6th novel in A Song of Ice and Fire."
                },
                new Book()
                {
                    Id = new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                    AuthorId = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    Title = "A Dance with Dragons",
                    Description =
                        "A Dance with Dragons is the fifth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin."
                },
                new Book()
                {
                    Id = new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                    AuthorId = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    Title = "American Gods",
                    Description =
                        "American Gods is a Hugo and Nebula Award-winning novel by English author Neil Gaiman. The novel is a blend of Americana, fantasy, and various strands of ancient and modern mythology, all centering on the mysterious and taciturn Shadow."
                },
                new Book()
                {
                    Id = new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                    AuthorId = new Guid("578359b7-1967-41d6-8b87-64ab7605587e"),
                    Title = "Speechless",
                    Description =
                        "Good-natured and often humorous, Speechless is at times a 'song of curses', as Lanoye describes the conflicts with his beloved diva of a mother and her brave struggle with decline and death."
                },
                new Book()
                {
                    Id = new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                    AuthorId = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description =
                        "The Hitchhiker's Guide to the Galaxy is the first of five books in the Hitchhiker's Guide to the Galaxy comedy science fiction 'trilogy' by Douglas Adams."
                },
                new Book()
                {
                    Id = new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                    AuthorId = new Guid("a1da1d8e-1988-4634-b538-a01709477b77"),
                    Title = "Easy Money",
                    Description =
                        "Easy Money or Snabba cash is a novel from 2006 by Jens Lapidus. It has been a success in term of sales, and the paperback was the fourth best seller of Swedish novels in 2007."
                });
        }
    }
}
