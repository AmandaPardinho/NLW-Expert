using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories
{
    public class AuctionConfig : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Auctions");

            builder.Property(act => act.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(act => act.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(act => act.Starts)
                .HasColumnName("Starts")
                .HasColumnType("datetime");

            builder.Property(act => act.Ends)
                .HasColumnName("Ends")
                .HasColumnType("datetime");

            builder.Property<DateTime>("lastUpdated")
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnName("LastUpdated")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
