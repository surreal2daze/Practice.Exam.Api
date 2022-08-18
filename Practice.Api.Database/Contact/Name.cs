using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Api.Database.Contact
{
    [ComplexType]
    public class Name
    {
        public string first { get; set; }
        public string middle { get; set; }
        public string last { get; set; }
    }

    //public class NameBuilder : IEntityTypeConfiguration<Name>
    //{
    //    public void Configure(EntityTypeBuilder<Name> builder)
    //    {
    //        builder
    //            .Property(x => x.first)
    //            .HasColumnName("first")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");

    //        builder
    //            .Property(x => x.middle)
    //            .HasColumnName("middle")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");

    //        builder
    //            .Property(x => x.last)
    //            .HasColumnName("last")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");
    //    }
    //}
}