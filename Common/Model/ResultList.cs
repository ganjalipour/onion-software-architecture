using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consulting.Common.Model
{
    public class ResultList
    {
        public ResultList()
        {
            MaxPageRows = 50;
        }
        public int TotalRows { get; set; }
        public int MaxPageRows { get; set; }
        public object Results { get; set; }
        public IEnumerable<Entity> entities { get; set; }
        public IEnumerable<ServerErr> ServerErrors { get; set; }
    }
}
