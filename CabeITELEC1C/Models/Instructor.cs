namespace CabeITELEC1C.Models
{
    public enum Rank
    {
        Instructor, AssistantProfessor, PAssociateProfessor, Professor
    }

    public class Instructor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Boolean IsTenured { get; set; }

        public DateTime HiringDate { get; set; }

        public Rank Rank { get; set; }
    }
}
