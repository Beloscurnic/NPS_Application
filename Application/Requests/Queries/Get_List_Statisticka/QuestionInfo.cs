using static Domain.EnumCore;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class QuestionInfo
        {
            public TypeQuestion TypeQuestion { get; set; }
            public string? Name_Question { get; set; } //json
            public IList<Answert_List> Info_ListAnswerts { get; set; }   
            public IDictionary<int, Answert_Dictionary>? Info_DictionaryAnswerts { get; set; }
        }
        public class Answert_List
        {
            public int IDAnswert { get; set; }
            public int Count { get; set; }
            public string Name { get; set; }

        }
        public class Answert_Dictionary
        {
            public int Count { get; set; }
            public string Name { get; set; }
        }
    }
}
