using DataLayer.Entity;
using System;

namespace BusinessLayer.Models.DTO
{
    public class CarTechnicalCondition : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Milleage { get; set; }
        public bool BreakSystem { get; set; }
        public bool Suspension { get; set; }
        public bool Wheels { get; set; }
        public bool Lighting { get; set; }
        public double CarbonDioxideContent { get; set; }
        public int InspectorId { get; set; }
        public int CarId { get; set; }
        public bool InspectionMark { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {Date} {Milleage} {BreakSystem} {Suspension} {Wheels} {Lighting} {CarbonDioxideContent} {InspectorId} {CarId} {InspectionMark}";
        }
    }
}
