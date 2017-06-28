using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmAdministration.Entities.DomainModels
{
   public class Inventory
    {
        public Inventory(string applicationUserId)
        {
            this.ApplicationUserId = applicationUserId;
        }
        [Key]
        public int Id { get; private set; }

        public int HistoryId { get; set; }

        public History History { get; set; }

        [Required]
        public string ApplicationUserId { get; private  set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public InventoryType Type { get; set; }
    }
}
