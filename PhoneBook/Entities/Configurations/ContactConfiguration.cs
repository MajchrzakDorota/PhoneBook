using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Entities.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(c => c.MobileNumber)
                .IsRequired()
                .HasMaxLength(9);
            builder.HasData(
                new Contact {Id = 1,  Name = "Mother", MobileNumber = "236448569", GroupId=1 },
                new Contact {Id = 2, Name = "Dad", MobileNumber = "856994785", GroupId = 1 },
                new Contact {Id = 3,  Name = "John", MobileNumber = "741002569", GroupId = 2 }
                );
            
                
        }
    }

}
