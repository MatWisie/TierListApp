﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierListApp.DTO
{
    public class TierListDTO
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
