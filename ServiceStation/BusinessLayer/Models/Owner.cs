using DataLayer.Entity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BusinessLayer.Models.DTO
{
    [DataContract]
    public class Owner : IEntity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string PhoneNum { get; set; }
        public override string ToString()
        {
            return $"{Id} {Firstname} {LastName} {MiddleName} {PhoneNum}";
        }
    }
}
