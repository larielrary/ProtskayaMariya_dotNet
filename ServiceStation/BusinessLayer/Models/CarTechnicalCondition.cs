using DataLayer.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.DTO
{
    public class CarTechnicalCondition : IEntity
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Milleage { get; set; }
        [Required]
        public bool BreakSystem { get; set; }
        [Required]
        public bool Suspension { get; set; }
        [Required]
        public bool Wheels { get; set; }
        [Required]
        public bool Lighting { get; set; }
        [Required]
        public double CarbonDioxideContent { get; set; }
        [Required]
        public int InspectorId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public bool InspectionMark { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {Date} {Milleage} {BreakSystem} {Suspension} {Wheels} {Lighting} {CarbonDioxideContent} {InspectorId} {CarId} {InspectionMark}";
        }
    }
}
