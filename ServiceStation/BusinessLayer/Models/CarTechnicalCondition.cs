using DataLayer.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BusinessLayer.Models.DTO
{
    [DataContract]
    public class CarTechnicalCondition : IEntity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public double Milleage { get; set; }
        [DataMember]
        public bool BreakSystem { get; set; }
        [DataMember]
        public bool Suspension { get; set; }
        [DataMember]
        public bool Wheels { get; set; }
        [DataMember]
        public bool Lighting { get; set; }
        [DataMember]
        public double CarbonDioxideContent { get; set; }
        [DataMember]
        public int InspectorId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public bool InspectionMark { get; set; }
        public override string ToString()
        {
            return $"{Id} {Date} {Milleage} {BreakSystem} {Suspension} {Wheels} {Lighting} {CarbonDioxideContent} {InspectorId} {CarId} {InspectionMark}";
        }
    }
}
