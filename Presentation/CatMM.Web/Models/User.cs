﻿using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatMM.Web.Models
{
    public class User
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public SubUser Object { get; set; }
    }

    public class SubUser : Drop
    {
        public int? Age { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

    }
}