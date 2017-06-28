using System;
using System.ComponentModel.DataAnnotations;

namespace FirmAdministration.Entities.DomainModels
{
    public class History
    {
        [Key]
        public int Id { get; set; }      
        public DateTime? AssignDate { get; set; }
        public DateTime? RemoveDate { get; set; }   


    }
}
