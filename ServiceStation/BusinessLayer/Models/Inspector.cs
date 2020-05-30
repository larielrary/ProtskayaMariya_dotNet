using DataLayer.Entity;

namespace BusinessLayer.Models.DTO
{
    public class Inspector : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {Firstname} {LastName} {MiddleName} {Position} {Salary}";
        }
    }
}
