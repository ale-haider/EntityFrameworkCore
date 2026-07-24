namespace EntityFrameworkCore.Domain
{
    public class Team : BaseDomainModel
    {
        //public int Id { get; set; } // inherits from BaseDomainMOdel
        public string? Name { get; set; }

        public int LeagueId { get; set; }   

        public int CoachId { get; set; }
    }   
}
