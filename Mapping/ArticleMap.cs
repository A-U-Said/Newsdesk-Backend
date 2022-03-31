using NewsDesk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewsDesk.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> articleBuilder)
        {
            articleBuilder.ToTable("Articles");
            articleBuilder.HasKey(x => x.Id);
            articleBuilder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            articleBuilder.Property(x => x.Title);
            articleBuilder.Property(x => x.Body);
            articleBuilder.Property(x => x.PublishedDate);
            articleBuilder.Property(x => x.AuthorId);
            articleBuilder.Property(x => x.CategoryId);

            articleBuilder.HasOne(x => x.Category)
                            .WithMany(category => category.ArticlesClassed)
                            .HasForeignKey(x => x.CategoryId)
                            .OnDelete(DeleteBehavior.Cascade);

            articleBuilder.HasOne(x => x.Author)
                            .WithMany(author => author.ArticlesWritten)
                            .HasForeignKey(x => x.AuthorId)
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
