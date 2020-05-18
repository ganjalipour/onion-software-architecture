using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.BasicDto
{
    public class ResultListDto
    {
        public ResultListDto()
        {
            ServerErrors = new List<ServerErr>();
        }

        public int TotalRows { get; set; }
        public int MaxPageRows { get; set; }
        public object Results { get; set; }
        public IList<ServerErr> ServerErrors { get; set; }
    }
}
