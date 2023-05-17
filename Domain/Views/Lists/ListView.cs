﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Lists
{
    public class ListView
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string DestinationCountry { get; set; } = null!;
        public string DestinationCity { get; set; } = null!;
    }
}