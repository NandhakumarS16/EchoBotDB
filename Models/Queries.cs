using System;
using System.Collections.Generic;

namespace EchoBotDB.Models
{
    public partial class Queries
    {
        public int Sno { get; set; }
        public string Request { get; set; }
        public string Keyword1 { get; set; }
        public string Keyword2 { get; set; }
        public string Keyword3 { get; set; }
        public string Response { get; set; }
    }
}
