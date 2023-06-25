using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierListApp.Models
{
    public class TierItem
    {
        [Key]
        public int Id { get; set; }
        public string Source { get; set; }
        public string? Note { get; set; }

        public int TierListId { get; set; }
        public int? TierId { get; set; }
        public Tier Tier { get; set; }
        public TierList TierList { get; set; }
    }
}
