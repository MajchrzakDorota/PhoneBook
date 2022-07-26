using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Entities.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.GroupName)
                .IsRequired();

            builder.HasMany(c => c.Contacts)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId);

            builder.HasData(
                new Group {Id = 1, GroupName = "Family"},
                new Group {Id = 2, GroupName = "Friends" },
                new Group {Id = 3, GroupName = "Work" }
                );
        }
    }
}
