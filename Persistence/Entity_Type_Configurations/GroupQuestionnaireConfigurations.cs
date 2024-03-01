using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entity_Type_Configurations
{
    public class GroupQuestionnaireConfigurations : IEntityTypeConfiguration<GroupQuestionnaire>
    {
        public void Configure(EntityTypeBuilder<GroupQuestionnaire> builder)
        {
       //     builder.HasOne(e => e._Oprostnik)
       //.WithOne(e => e.Group_Questionnaire)
       //.OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
