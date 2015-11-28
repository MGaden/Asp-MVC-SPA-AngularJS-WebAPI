using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.ViewModel
{
    public class DataResult
    {
        public bool Sucess { get; set; }
        public List<string> Messages { get; set; }
    }
}