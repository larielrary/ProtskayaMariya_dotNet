using DataLayer.Entity;

namespace DataLayer.Models
{
    public class InspectorDTO : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
    }
}
