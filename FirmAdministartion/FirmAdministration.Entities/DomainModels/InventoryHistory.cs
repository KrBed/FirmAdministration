using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmAdministration.Entities.DomainModels
{
   public class InventoryHistory
    {
        [Key]
        [Column(Order = 1)]
        public int InventoryId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int HistoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual History History { get; set; }


    }
}
