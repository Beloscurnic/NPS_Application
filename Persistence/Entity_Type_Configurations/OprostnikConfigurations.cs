using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entity_Type_Configurations
{
    public class OprostnikConfigurations : IEntityTypeConfiguration<Oprostnik>
    {
        public void Configure(EntityTypeBuilder<Oprostnik> builder)
        {
        }
    }
}
