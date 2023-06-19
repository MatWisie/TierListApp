using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TierListApp.Models
{
    public class Tier : ObservableObject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string TierColor { get; set; }

        public int TierListId { get; set; }
        public TierList TierList { get; set; }

        public ObservableCollection<TierItem> TierItems { get; set; }
    }
}
