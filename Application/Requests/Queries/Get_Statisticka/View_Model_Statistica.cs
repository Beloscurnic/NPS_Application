namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class View_Model_Statistica
        {
            public int QuestionID { get; set; }
            public string? Name_Question { get; set; }
            public IDictionary<int, InfoAnswert>? Questions_Variants { get; set; } = new Dictionary<int, InfoAnswert>();
            public int OprostnikID { get; set; }
        }
    }
}
