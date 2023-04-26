﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }
    }
}
