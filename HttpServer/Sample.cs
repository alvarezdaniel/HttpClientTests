﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace HttpServer
{
    public class Sample : NancyModule
    {
        public Sample()
        {
            Get["/"] = _ => "Hello";
        }
    }
}
