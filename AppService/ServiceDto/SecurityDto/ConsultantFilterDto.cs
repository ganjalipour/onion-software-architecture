using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "ConsultantFilterDto")]

    public class ConsultantFilterDto : BaseFilterDto
    {

    }
}
