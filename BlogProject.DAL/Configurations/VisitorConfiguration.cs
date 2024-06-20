using BlogProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Configurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);
        }
    }
}
