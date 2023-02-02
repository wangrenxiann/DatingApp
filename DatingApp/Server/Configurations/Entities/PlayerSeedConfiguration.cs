using DatingApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Server.Configurations.Entities
{
    public class PlayerSeedConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Player> builder)
        {
            builder.HasData(
            new Player
            {
                Id = 1,
                FirstName = "Wong",
                LastName = "Kukubird",
                Address="520875 tampines st09 #100-0",
                ContactNumber="98765432",
                EmailAddress ="Wongkkb@gmail.com",
                Gender="M",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            }, 
            new Player
            {
                Id = 2,
                FirstName = "Su",
                LastName = "Susan",
                Address = "567892 tampines st20 #50-0",
                ContactNumber = "91234567",
                EmailAddress = "Suuuuuuuuuuuuuuuuu@gmail.com",
                Gender = "F",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            }
);
        }
    }
}
