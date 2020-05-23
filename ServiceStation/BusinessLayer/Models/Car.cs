using DataLayer.Entity;

namespace BusinessLayer.Models.DTO
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }
        public string CarModel { get; set; }
        public double EngineCapacity { get; set; }
        public string BodyNubmer { get; set; }
        public int YearOfProduction { get; set; }
        public int OwnerId { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {CarNumber} {CarModel} {EngineCapacity} {BodyNubmer} {YearOfProduction} {OwnerId}";
        }
    }
}
