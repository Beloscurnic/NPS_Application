using Application.Requests.Commands.Upsert_QuestionVariant;
namespace NPS_WebAPI.Model.Upsert_QuestionVariant
{
    public class UpsertListQuestionVariant_DTO
    {
        public IList<QuestionVaraint_Upsert.Command> UpsertVariantQuestions { get; set; }
        public int QuestionID { get; set; }
        public int OprostnikID { get; set; }    
    }
}
