using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using Consulting.Common.Utility;
using Consulting.Domains.Core.Core.Entities;
using Consulting.Domains.Core.Entities;
using System;
using Consulting.Common.Dto;
using Consulting.Applications.AppService.ServiceDto.Statistics;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Domains.Core.Core.Service;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;

using Consulting.Common.Model;
using Consulting.Domains.Customer.Entities;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Domains.Core.Consult.Entities;

namespace Consulting.Applications.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "Dto" || s.Name + "Dto" == d.Name);
            AddConditionalObjectMapper().Where((s, d) => d.Name == "KeyValueDto");
            AddConditionalObjectMapper().Where((s, d) => s.Name == "KeyValueDto");

            AddMemberConfiguration().AddName<ReplaceName>(_ => _.AddReplace("Date", "DateFa"));
            AddMemberConfiguration().AddName<ReplaceName>(_ => _.AddReplace("Date", "DateEn"));

            ValidateInlineMaps = false;
            RecognizePrefixes("User", "Role", "Branch", "Zone", "AttachmentType",
                "Nationality" , "MilitaryServiceStatus", "EducationLevels" ,"CustomerHead","Sort"
                , "ConsultType", "UserBranchRole", "BaseFilter" , "Skill");

            CreateMap<Zone, KeyValueDto>().ForMember(dest => dest.Code, opt => opt.MapFrom((src => src.OSTAN == null ? (src.SHAHRESTAN == null ? src.Abadi : src.SHAHRESTAN) : src.OSTAN)))
           .ForMember(dest => dest.Desc, opt => opt.MapFrom((src => src.OstanName == null ? (src.ShahrestName == null ? src.AbadiName : src.ShahrestName) : src.OstanName))).ReverseMap();

            CreateMap<GeneralStatisticsDAO, GeneralStatisticsDto>().ReverseMap();
            CreateMap<MessageJoinModel, MessageDto>().ReverseMap();

            CreateMap<ResultListDto, ResultList>().ReverseMap();

            CreateMap<AttachmentType, KeyValueDto>().ForMember(des => des.Desc, opt => opt.MapFrom(src => src.AttachmentTypeDesc))
               .ForMember(des => des.Code, opt => opt.MapFrom(src => src.AttachmentTypeCode))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.AttachmentTypeName))
               .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID)).ReverseMap();



            CreateMap<CustomerHead, KeyValueDto>().ForMember(des => des.Desc, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).ReverseMap();

            CreateMap<User, KeyValueDto>().ForMember(des => des.Desc, opt => opt.MapFrom(src => src.UserName))
              .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID))
              .ReverseMap();

            CreateMap<CustomerInfoForDepositDto, CustomerInfoForDeposit>().ReverseMap();

            //CreateMap<Consultant, ConsultantDto>().ForMember(dest =>dest.User, 
            //    opt => opt.MapFrom(src => src.User)).ReverseMap();


            CreateMap<DateTime, string>().ConvertUsing(new DateTimeToPersianDateTimeConverter());
            CreateMap<string, DateTime>().ConvertUsing(new PersianDateTimeToDateTimeConverter());

            CreateMap<Sort, Sort>().ForMember(des => des.field, opt => opt.MapFrom(src => src.field.Contains("Fa") ? src.field.Remove(src.field.Length - 2) : src.field))
            .ForMember(des => des.field, opt => opt.MapFrom(src => src.field.Contains("userStatusDesc") ? src.field.Replace("userStatusDesc", "IsActive") : src.field))
            .ForMember(des => des.field, opt => opt.MapFrom(src => src.field.Contains("loanType.loanTypeDesc") ? null : src.field));
           
        }
    }

    public class DateTimeToPersianDateTimeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return DateConvertor.Instance.ConvertGregorianToPersianDate(source);
        }
    }

    public class PersianDateTimeToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return DateConvertor.Instance.ConvertPersianDatetimeToGregorian(source);
        }       
    }

    public class Converter
    {
        public string Convert(string source, string destination, ResolutionContext context)
        {
            if (source.Contains("FA"))
                return source.Remove(-2);
            return source;
        }
    }

}
