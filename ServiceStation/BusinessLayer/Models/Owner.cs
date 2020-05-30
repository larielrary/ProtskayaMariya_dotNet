using DataLayer.Entity;

namespace BusinessLayer.Models.DTO
{
    public class Owner : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNum { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {Firstname} {LastName} {MiddleName} {PhoneNum}";
        }
    }
}
