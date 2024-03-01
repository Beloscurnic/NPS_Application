using Domain;

namespace NPS_WebAPI.Model
{
    public class Creat_GroupQuestionnaire_DTO
    {
        public int? Id_GroupQuestionnaire { get; set; }
        public string Name { get; set; }
        // public Oprostnik? Oprostnik { get; set; }
        public Guid? LincenseID { get; set; }
        public int? IDOprostnik { get; set; }   
    }
}
