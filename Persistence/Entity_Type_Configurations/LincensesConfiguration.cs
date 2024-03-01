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
    public class LincensesConfiguration: IEntityTypeConfiguration<Lincense>
    {
        public void Configure(EntityTypeBuilder<Lincense> builder)
        {
            // builder.HasOne(e => e.Group_Questionnaire)
            //.WithOne(e => e.Lincense)
            //.OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
