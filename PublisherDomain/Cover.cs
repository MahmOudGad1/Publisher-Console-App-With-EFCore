﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherDomain
{
    public class Cover
    {
        public int CoverId { get; set; }
        public string DesignIdeas {  get; set; }
        public bool DegetalOnly { get; set; }   
        public List<Artist> Artists { get; set; } 

    }
}
