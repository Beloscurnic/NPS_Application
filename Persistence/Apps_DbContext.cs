using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Entity_Type_Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Apps_DbContext : DbContext, I_DbContext
    {
        public DbSet<Lincense> Lincenses { get; set; }
        public DbSet<GroupQuestionnaire> GroupQuestions { get; set; }
        public DbSet<Oprostnik> Oprostniks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Questions_Variant> Questions_Variants { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public Apps_DbContext(DbContextOptions<Apps_DbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GroupQuestionnaireConfigurations());
            builder.ApplyConfiguration(new LincensesConfiguration());
            builder.ApplyConfiguration(new OprostnikConfigurations());

            base.OnModelCreating(builder);

        }
    }
}
