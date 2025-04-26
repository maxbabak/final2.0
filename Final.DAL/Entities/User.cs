﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
