using DataLayer.Entity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BusinessLayer.Models.DTO
{
    [DataContract]
    public class Car : IEntity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CarNumber { get; set; }
        [DataMember]
        public string CarModel { get; set; }
        [DataMember]
        public double EngineCapacity { get; set; }
        [DataMember]
        public string BodyNubmer { get; set; }
        [DataMember]
        public int YearOfProduction { get; set; }
        [DataMember]
        public int OwnerId { get; set; }
        public override string ToString()
        {
            return $"{Id} {CarNumber} {CarModel} {EngineCapacity} {BodyNubmer} {YearOfProduction} {OwnerId}";
        }
    }
}
