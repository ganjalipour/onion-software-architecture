using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Consulting.Common.Resources;
using System.Collections.Generic;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Applications.AppService.ServiceDto.BasicDto;

namespace Consulting.Applications.AppService.ServiceDto.Sessions
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "SessionMessageDto")]
    public class SessionMessageDto:MessageDto
    {
        public string BranchName { get; set; }

        public string SessionAddress { get; set; }

        public ICollection<SessionUsersDto> SessionUsers { get; set; }

        public string SessionDate { get; set; }

    }
}
