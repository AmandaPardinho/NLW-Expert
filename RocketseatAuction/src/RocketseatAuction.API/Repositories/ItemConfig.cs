using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.Property(it => it.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(it => it.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(it => it.Brand)
                .HasColumnName("Brand")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(it => it.Condition)
                .HasColumnName("Condition")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(it => it.BasePrice)
                .HasColumnName("BasePrice")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(it => it.AuctionId)
                .HasColumnName("AuctionId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property<DateTime>("lastUpdated")
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnName("LastUpdated")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(it => it.Auction)
                .WithMany(act => act.Items)
                .HasForeignKey(it => it.AuctionId);
        }
    }
}
