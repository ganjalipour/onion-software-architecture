using AutoMapper;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Applications.Notification;
using Consulting.Common.Collections;
using Consulting.Common.Constants;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Service;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Applications.Customer
{
    public class CustomerAppService
    {
        private CustomerService _customerService;
        private UserAppService _userAppService;
        private UserService _userService;
        private NotificationAppService _notificationAppService;
        private readonly IMapper _mapper;
        private ITransactionManager _transactionManager;
        public ZoneService _zoneService;
        public BranchService _branchService;


        public CustomerAppService(CustomerService customerService, ITransactionManager transactionManager, UserAppService userAppService, UserService userService,
            IMapper mapper, ZoneService zoneService, NotificationAppService notificationAppService, BranchService branchService)
        {
            _customerService = customerService;
            _userService = userService;
            _notificationAppService = notificationAppService;
            _mapper = mapper;
            _userAppService = userAppService;
            _transactionManager = transactionManager;
            _zoneService = zoneService;
            _branchService = branchService;
        }

        public async Task<CustomerHeadDto> GetCustomerAsync(int customerNumber)
        {
            var customerInfo = await _customerService.GetCustomerAsync(customerNumber);
            CustomerHeadDto result = new CustomerHeadDto();
            result = _mapper.Map<CustomerHeadDto>(customerInfo);

            result.CustomerDetails = new List<CustomerDetailDto>();


            customerInfo.CustomerDetails.ForEach(x =>
            {
                result.CustomerDetails.Add(new CustomerDetailDto()
                {
                    Code = x.CustomerDetailType.Code,
                    Value = x.Value,
                    ID = x.ID
                });
            });
            return result;
        }

        public async Task<CustomerHeadDto> GetCustomerByUserIDAsync(int userID)
        {
            var customerInfo = await _customerService.GetCustomerByUserIDAsync(userID);
            CustomerHeadDto result = new CustomerHeadDto();
            result = _mapper.Map<CustomerHeadDto>(customerInfo);

            return result;
        }


        public async Task<CustomerHeadDto> GetCustomerByCustomerIdAsync(int customerId)
        {
            var customerInfo = await _customerService.GetCustomerByCustomerIdAsync(customerId);
            var zone = await _zoneService.GetZoneByBranchIDAsync(customerInfo.BranchID);

            //  CustomerHeadDto result = new CustomerHeadDto();
            var result = _mapper.Map<CustomerHeadDto>(customerInfo);
            result.Zone = _mapper.Map<ZoneDto>(zone);
            result.CustomerDetails = new List<CustomerDetailDto>();
            result.BranchName = _branchService.GetBranchByBranchCodeAsync(customerInfo.BranchCode).Result.BranchName;


            customerInfo.CustomerDetails.ForEach(x =>
            {
                result.CustomerDetails.Add(new CustomerDetailDto()
                {
                    Code = x.CustomerDetailType.Code,
                    Value = x.Value,
                    ID = x.ID
                });
            });
            return result;
        }

        public async Task<ResultListDto> GetCustomersByFilterAsync(CustomerFilterDto customerFilterDto)
        {
            var userBranches = _mapper.Map<UserBranches>(customerFilterDto.UserBranchDto);
            if (customerFilterDto.Branches == null || customerFilterDto.Branches.Count == 0)
                customerFilterDto.Branches = await _branchService.GetBranchesForFiltersAsync(userBranches);

            var customerFilter = _mapper.Map<CustomerFilter>(customerFilterDto);
            var customerList = await _customerService.GetCustomersByFilterAsync(customerFilter);
            var customerDtoList = _mapper.Map<List<CustomerHeadDto>>(customerList.Results);

            customerDtoList.ForEach(x =>
            {
                x.CustomerDetails.ForEach(d =>
                {
                    if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.Mobile)
                        x.MobileCustomerDetail = d;

                    if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.HomePhone)
                        x.HomePhoneCustomerDetail = d;

                    if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.HomeAddress)
                        x.HomeAddressCustomerDetail = d;

                    if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.WorkPhone)
                        x.WorkPhoneCustomerDetail = d;

                    if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.WorkAddress)
                        x.WorkAddressCustomerDetail = d;

                    //if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.CertificateImage)
                    //    x.CertificateImageCustomerDetail = d;

                    //if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.PersonalImage)
                    //    x.PersonalImageCustomerDetail = d;

                    //if (d.CustomerDetailTypeID == ConstCustomerDetailsTypes.SignatureImage)
                    //    x.SignatureImageCustomerDetail = d;
                });

                x.CustomerDetails = new List<CustomerDetailDto>();
            });

            foreach (var item in customerDtoList)
            {
                foreach (var item2 in item.CustomerSkills)
                {
                    item.Skills.Add(item2.SkillID);
                }
            }

            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = customerList.MaxPageRows,
                TotalRows = customerList.TotalRows,
                Results = customerDtoList
            };
            return finalResult;
        }

        public async Task<ResultListDto> GetAllBranchCustomerHeadsAsync(CustomerFilterDto customerFilter)
        {
            //var userBranches = _mapper.Map<UserBranches>(customerFilterDto.UserBranchDto);

            //var customerFilter = _mapper.Map<CustomerFilter>(customerFilterDto);

            var customerFilterr = _mapper.Map<CustomerFilter>(customerFilter);

            var customerList = await _customerService.GetAllBranchCustomerHeadsAsync(customerFilterr);

            var customerDtoList = _mapper.Map<List<KeyValueDto>>(customerList.Results);


            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = customerList.MaxPageRows,
                TotalRows = customerList.TotalRows,
                Results = customerDtoList
            };
            return finalResult;
        }

        public async Task<ResultListDto> GetCustomersAsync()
        {
            var customerList = await _customerService.GetCustomersAsync();
            var customerDtoList = _mapper.Map<IEnumerable<CustomerHeadDto>>(customerList);
            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = 50,
                TotalRows = 100,
                Results = customerDtoList
            };
            return finalResult;
        }


        public async Task<IEnumerable<KeyValueDto>> GetMilitaryServiceStatus()
        {
            var militaryServices = await _customerService.GetMilitaryServiceStatus();

            List<KeyValueDto> keyValueDtoes = new List<KeyValueDto>();
            militaryServices.ForEach(x =>
              {
                  keyValueDtoes.Add(new KeyValueDto() { ID = x.ID, Desc = x.MilitaryServiceStatusDesc });
              }
            );

            //   var militaryServiceList = _mapper.Map<IEnumerable<KeyValueDto>>(militaryService);

            //return militaryServiceList;
            return keyValueDtoes;
        }

        public async Task<IEnumerable<KeyValueDto>> GetNationalities()
        {
            var nationalities = await _customerService.GetNationalities();
            var nationalityListDto = _mapper.Map<IEnumerable<KeyValueDto>>(nationalities);
            return nationalityListDto;
        }


        public async Task<IEnumerable<KeyValueDto>> GetEducationLevels()
        {
            var educationals = await _customerService.GetEducationLevels();
            List<KeyValueDto> keyValueDtoes = new List<KeyValueDto>();
            educationals.ForEach(x =>
            {
                keyValueDtoes.Add(new KeyValueDto() { ID = x.ID, Desc = x.EducationLevelsDesc });
            }
            );
            // var educationalsListDto = _mapper.Map<IEnumerable<KeyValueDto>>(educationals);
            return keyValueDtoes;
        }

        public async Task<IEnumerable<KeyValueDto>> GetSkills()
        {
            var skills = await _customerService.GetSkills();
            var result = _mapper.Map<IEnumerable<KeyValueDto>>(skills);
            return result;
        }

        public ResultObject ValidateCustomerDetail(CustomerHeadDto customerDto, ResultObject resultObject)
        {
            if (customerDto.MobileCustomerDetail.Value == null)
            {
                resultObject.ServerErrors.Add(new ServerErr() { Hint = "پر کردن موبایل مشتری الزامی است" });
                return resultObject;
            }

            if (customerDto.HomeAddressCustomerDetail.Value == null)
            {
                resultObject.ServerErrors.Add(new ServerErr() { Hint = "پر کردن فیلد آدرس منزل الزامی است" });
                return resultObject;
            }

            if (customerDto.HomePhoneCustomerDetail.Value == null)
            {
                resultObject.ServerErrors.Add(new ServerErr() { Hint = "پر کردن فیلد  تلفن منزل الزامی است" });
                return resultObject;
            }

            return resultObject;

        }

        public async Task<ResultObject> CreateCustomerAsync(CustomerHeadDto customerDto)
        {
            ResultObject result = new ResultObject();
            var cu = await _customerService.GetCustomerByNationalCodeAndBranchIDAsync(customerDto.NationalCode);
            if (cu != null)
            {
                result.ServerErrors.Add(new ServerErr() { Hint = "کد ملی مشتری نمیتواند تکراری باشد" });
                return result;
            }
            customerDto.FillCustomerDetail();
            result = ValidateCustomerDetail(customerDto, result);
            if (result.ServerErrors.Count > 0)
                return result;

            var customer = _mapper.Map<CustomerHead>(customerDto);
            if (customerDto.Skills != null && customerDto.Skills.Count > 0)
                foreach (var skillID in customerDto.Skills)
                {
                    customer.CustomerSkills.Add(new CustomerSkill() { SkillID = skillID });
                }

            var mainUser = await _userAppService.GetUserByNationalCodeAsync(customerDto.NationalCode);
            User user = new User();
            IDbContextTransaction transaction;
            if (mainUser == null)
            {
                user.FirstName = customerDto.FirstName;
                user.LastName = customerDto.LastName;
                user.UserName = customerDto.NationalCode;
                user.NationalCode = customerDto.NationalCode;
                user.IsActive = true;
                user.IsRequireChangePass = true;
                user.Password = "12345678";

                UserBranches userBranch = new UserBranches() { BranchId = customerDto.BranchID, UserId = user.ID };
                UserBranchRole userBranchRole = new UserBranchRole() { BranchId = customerDto.BranchID, UserId = user.ID, RoleId = ConstRoles.Customer };
                user.UserBranches.Add(userBranch);
                user.UserBranchRoles.Add(userBranchRole);
                transaction = await _userService.CreateUserByUserBranchAsync(user);
                await _transactionManager.SaveAllAsync();

                customer.CustomerUserID = user.ID;
                await _customerService.CreateCustomerAsync(customer);

                var res = await _transactionManager.SaveAllAsync();
                transaction.Commit();
            }
            else
            {
                if (result.ServerErrors.Count > 0)
                    return result;
                customer.CustomerUserID = mainUser.ID;
                await _customerService.CreateCustomerAsync(customer);
                var res = await _transactionManager.SaveAllAsync();
            }

            if (customer.IsMale)
            {
                _notificationAppService.SendMessage($"جناب آقای {customer.FirstName + " " + customer.LastName} " +
                    $"{Environment.NewLine} اطلاعات شما با شماره مشتری {customer.Serial} در سامانه صندوق های خرد محلی {customerDto.BranchName} ثبت گردید {Environment.NewLine} نام کاربری {user.UserName}",
                  customerDto.MobileCustomerDetail.Value);
            }
            else
            {
                _notificationAppService.SendMessage($"سرکار خانم {customer.FirstName + " " + customer.LastName} {Environment.NewLine} اطلاعات شما با شماره مشتری {customer.Serial} در سامانه صندوق های خرد محلی {customerDto.BranchName} ثبت گردید {Environment.NewLine} نام کاربری {user.UserName}",
                 customerDto.MobileCustomerDetail.Value);
            }

            result.Result = customer.Serial;
            result.ServerErrors = null;
            return result;
        }


        //public async Task<Account> CreateAccountAsync(AccountDto accountDto)
        //{
        //    //باز کردن موقتی حساب
        //    accountDto.AccountStatusID = ConstAccountStatuses.Open;

        //    Branch branch = await branchAppService._branchService.GetBranchAsync(accountDto.BranchID);

        //    accountDto.BranchCode = branch.BranchCode;
        //    var account = mapper.Map<Account>(accountDto);
        //    await accountService.CreateAccountAsync(account);

        //    var result = await transactionManager.SaveAllAsync();

        //    return account;
        //}


        public async Task<ResultObject> UpdateCustomerAsync(CustomerHeadDto customerDto)
        {
            ResultObject resultObject = new ResultObject();
            customerDto.FillCustomerDetail();
            var customerHead = _mapper.Map<CustomerHead>(customerDto);

            // بروز رسانی جزئیات مشتری
            foreach (var detail in customerHead.CustomerDetails)
            {
                if (detail.ID != 0)
                {
                    var customerDetailTask = await _customerService.UpdateCustomerDetailsAsync(detail);
                }
                else
                {
                    await _customerService.AddCustomerDetailsAsync(detail);
                }
            }

            foreach (var skill in customerDto.Skills)
            {
                customerHead.CustomerSkills.Add(new CustomerSkill()
                { CustomerID = customerHead.ID, SkillID = skill });
            }
            await _customerService.UpdateCustomerSkills(customerHead.CustomerSkills, customerHead.ID);
            var customerHeadTask = await _customerService.UpdateCustomerAsync(customerHead);
            await _transactionManager.SaveAllAsync();
            resultObject.Result = customerHeadTask.Serial;
            resultObject.ServerErrors = null;
            return resultObject;
        }


        public async Task DeleteCustomerAsync(int Id)
        {
            await _customerService.DeleteCustomerAsync(Id);
            await _transactionManager.SaveAllAsync();
        }

    }
}