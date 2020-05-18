using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Applications.AppService.ServiceDto.BasicDto
{
    public class BaseResultListFilterDto
    {
        public int ID { get; set; }
        public string RequestFromDateFa { get; set; }
        public string RequestToDateFa { get; set; }
        public string cellNumber { get; set; }
        public int PageNo { get; set; }
        public string PageRowCount { get; set; }
        public string refNo { get; set; }
        public int responseCode { get; set; }
        public long amount { get; set; }
        public byte psp { get; set; }
    }
}
