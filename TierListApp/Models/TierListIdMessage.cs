using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierListApp.Models
{
    public class TierListIdMessage
    {
        public int Id { get; set; }

        public TierListIdMessage(int id)
        {
            Id = id;
        }
    }
}
