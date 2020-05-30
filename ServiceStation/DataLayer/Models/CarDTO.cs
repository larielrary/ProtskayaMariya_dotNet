using DataLayer.Entity;

namespace DataLayer.Models
{
    public class CarDTO : IEntity
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }
        public string CarModel { get; set; }
        public double EngineCapacity { get; set; }
        public string BodyNubmer { get; set; }
        public int YearOfProduction { get; set; }
        public int OwnerId { get; set; }    
    }
}
