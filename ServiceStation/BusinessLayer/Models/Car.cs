using DataLayer.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.DTO
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string CarNumber { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public double EngineCapacity { get; set; }
        [Required]
        public string BodyNubmer { get; set; }
        [Required]
        public int YearOfProduction { get; set; }
        [Required]
        public int OwnerId { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {CarNumber} {CarModel} {EngineCapacity} {BodyNubmer} {YearOfProduction} {OwnerId}";
        }
    }
}
