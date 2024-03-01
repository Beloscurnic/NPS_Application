using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GroupQuestionnaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupQuestionnaireID { get; set; }

        public string Name { get; set; }
        public int? CompanyOID { get; set; }
        public virtual Oprostnik? _Oprostnik { get; set; }

        [ForeignKey("Lincense")]
        public Guid? LincenseID { get; set; }
        public virtual Lincense? Lincense { get; set; }
    }
}
