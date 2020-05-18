using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Consulting.Common.Resources;
using System.Collections.Generic;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;

namespace Consulting.Applications.AppService.ServiceDto.BasicDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "MessageDto")]
    public class MessageDto:BaseFilterDto
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Text { get; set; }
        public List<string> Reciviers { get; set; }
        public int SenderID { get; set; }
        public string SenderName { get; set; }

        public int recivierID { get; set; }

        public bool IsSeen { get; set; }

    }
}
