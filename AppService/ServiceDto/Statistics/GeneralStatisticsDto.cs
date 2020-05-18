using Consulting.Common.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Applications.AppService.ServiceDto.Statistics
{
    [ModelBinder(BinderType = typeof(CustomStringModelBinder), Name = "GeneralStatisticsDto")]

    public class GeneralStatisticsDto
    {
        public int TotalDepositsCount { get; set; }
      
        public int TotalCustomersCount { get; set; }

        public int TotalLoansCount { get; set; }

    }
}
