using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface I_DbContext
    {
        DbSet<Lincense> Lincenses { get; set; }
        DbSet<GroupQuestionnaire> GroupQuestions { get; set; }
        DbSet<Oprostnik> Oprostniks { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Questions_Variant> Questions_Variants { get; set; }
        DbSet<Response> Responses { get; set; }
        DbSet<Answer> Answers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
