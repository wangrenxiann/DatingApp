using DatingApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Server.Configurations.Entities
{
    public class MessageSeedConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
            new Message
            {
                Id = 1,
                MessageDesc = "Matter Baby",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Message
            {
                Id = 2,
                MessageDesc = "Whats Up",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            }
);
        }
    }
}
