using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.EnumCore;

namespace Domain
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public string? Response_QuestionVariant_ID { get; set; }//json

        [ForeignKey("Response")]
        public int ResponseID { get; set; }
        public virtual Response Response { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
