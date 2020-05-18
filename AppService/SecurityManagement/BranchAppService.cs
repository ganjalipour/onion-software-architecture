using AutoMapper;
using ExcelDataReader;
using Consulting.Applications.AppService.ServiceDto;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Constants;
using Consulting.Common.Data;
using Consulting.Common.Dto;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Consulting.Applications.Customer;

namespace Consulting.Applications.AppService.RoleManagement
{
    public class BranchAppService
    {
        public BranchService _branchService;
        public UserService _userService;
        private CustomerAppService _customerAppService;
        private ZoneService _zoneService;
        private readonly IMapper _mapper;
        private ITransactionManager _transactionManager;
        public BranchAppService(BranchService branchService, ITransactionManager transactionManager, IMapper mapper,
          CustomerAppService customerAppService, UserService userService, ZoneService zoneService)
        {
            _branchService = branchService;
            _customerAppService = customerAppService;
            _zoneService = zoneService;
            _userService = userService;
            _mapper = mapper;
            _transactionManager = transactionManager;
        }

        public async Task<ResultListDto> GetBranchesAsync(BranchFilterDto branchFilterDto)
        {
            if (branchFilterDto != null && branchFilterDto.UserBranchDto != null)
            {
                UserBranches userBranches = new UserBranches();
                userBranches = _mapper.Map<UserBranches>(branchFilterDto.UserBranchDto);
                if (branchFilterDto.Branches == null || branchFilterDto.Branches.Count == 0)
                    branchFilterDto.Branches = await _branchService.GetBranchesForFiltersAsync(userBranches);
            }
            var branchFilter = _mapper.Map<BranchFilter>(branchFilterDto);

            var branchList = await _branchService.GetBranchesAsync(branchFilter);

            var branchDtoList = _mapper.Map<IEnumerable<BranchDto>>(branchList.Results);

            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = branchList.MaxPageRows,
                TotalRows = branchList.TotalRows,
                Results = branchDtoList
            };
            return finalResult;
        }

        public async Task<ResultListDto> GetBranchesBaseOnRoleAsync(BranchFilterDto branchFilterDto)
        {
            List<int> branchList = new List<int>();
            ResultListDto resultListDto = new ResultListDto();

            var userRoles = await _userService.GetUserRolesAsync(branchFilterDto.UserBranchDto.BranchId, branchFilterDto.UserBranchDto.UserId);
            foreach (var item in userRoles)
            {
                if (item.RoleId == ConstRoles.Admin)
                {
                    var branchFilter = _mapper.Map<BranchFilter>(branchFilterDto);
                    var resultdto = await _branchService.GetBranchesAsync(branchFilter);
                    resultListDto = _mapper.Map<ResultListDto>(resultdto);
                    return resultListDto;
                }
                else if (item.RoleId == ConstRoles.User)
                {
                    var branches = await _branchService.GetUserBranches(branchFilterDto.UserBranchDto.UserId);
                    resultListDto.Results = branches;
                    return resultListDto;
                }
                else if (item.RoleId == ConstRoles.SuperViser)
                {
                    var branch = await _branchService.GetBranchAsync(branchFilterDto.UserBranchDto.BranchId);

                    var zone = await _zoneService.GetZoneInfoByZoneIDAsync(branch.ZoneID);

                    resultListDto.Results = await _zoneService.GetProvinceBranchesByProvinceCode(zone.OSTANCode);

                    return resultListDto;
                }
                //else if (item.RoleId == ConstRoles.Customer)
                //{
                //    //var customer = await _customerAppService.GetCustomerByUserIDAsync(branchFilterDto.UserBranchDto.UserId);
                //    //((DepositFilterDto)branchFilterDto).CustomerHeadSerial = customer.Serial;
                //}
                //else
                //{
                //    branchList.Add(branchFilterDto.UserBranchDto.BranchId);
                //    return branchList;
                //}
            }
            resultListDto.Results = await _branchService.GetBranchAsync(branchFilterDto.UserBranchDto.BranchId);
            resultListDto.ServerErrors = null;
            return resultListDto;
        }


        public async Task<List<int>> GetBranchesForFilter(UserBranchesDto userBranchesDto, BaseFilterDto baseFilterDto = null)
        {
            var userBranches = _mapper.Map<UserBranches>(userBranchesDto);
            BaseFilter baseFilter = new BaseFilter();
            if (baseFilterDto != null)
            {
                baseFilter = _mapper.Map<BaseFilter>(baseFilterDto);
            }

            return await _branchService.GetBranchesForFiltersAsync(userBranches, baseFilter);
        }


        public async Task<ResultListDto> GetBranchListAsync(BranchFilterDto branchFilterDto)
        {
            var branchFilter = _mapper.Map<BranchFilter>(branchFilterDto);
            var branchList = await _branchService.GetBranchListAsync(branchFilter);
            var branchDtoList = _mapper.Map<IEnumerable<BranchDto>>(branchList.Results);
            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = branchList.MaxPageRows,
                TotalRows = branchList.TotalRows,
                Results = branchDtoList
            };
            return finalResult;
        }




        public async Task<BranchDto> GetBranchAsync(int id)
        {
            var mybranch = await _branchService.GetBranchAsync(id);
            var branchDto = _mapper.Map<BranchDto>(mybranch);
            return branchDto;
        }




        public async Task<BranchDto> GetBranchByBranchCodeAsync(string branchCode)
        {
            var mybranch = await _branchService.GetBranchByBranchCodeAsync(branchCode);
            var branchDto = _mapper.Map<BranchDto>(mybranch);
            return branchDto;
        }


        // Matrixnet
        public async Task<ResultObject> CreateBranchFromExcelAsync(string path, BranchDto branchDto)
        {
            ResultObject resultObject = new ResultObject();
            var branch = _mapper.Map<Branch>(branchDto);
            branch.UserBranches.Add(new UserBranches()
            {
                BranchId = branch.ID,
                UserId = ConstUserIDs.Administrator
            });

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read()) //Each ROW
                        {
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                //Console.WriteLine(reader.GetString(column));//Will blow up if the value is decimal etc. 
                                Console.WriteLine(reader.GetValue(column));//Get Value returns object
                            }
                        }
                    } while (reader.NextResult()); //Move to NEXT SHEET

                }
            }

            resultObject.Result = branchDto;
            return resultObject;
        }


        public async Task<ResultObject> CreateBranchAsync(BranchDto branchDto)
        {
            ResultObject resultObject = new ResultObject();
            //var resultObject = await _accountService.GetBankAccountAmountAsync(0, branchDto.BDN);
            //if (resultObject.ServerErrors.Count > 0)
            //    return resultObject;
            //resultObject.ServerErrors = null;
            //decimal bdnAmount = resultObject.Result == null ? 0 : (decimal)resultObject.Result;
            var branch = _mapper.Map<Branch>(branchDto);
            branch.UserBranches.Add(new UserBranches()
            {
                BranchId = branch.ID,
                UserId =
                ConstUserIDs.Administrator
            });

            SetZoneIdForBranch(ref branchDto, ref branch);
            await _branchService.CreateBranchAsync(branch);
            var rsult = await _transactionManager.SaveAllAsync();
            resultObject.Result = branchDto;
            return resultObject;
        }



        private void SetZoneIdForBranch(ref BranchDto branchDto, ref Branch branch)
        {
            if (branchDto.ZoneId != null && branchDto.ZoneId != 0)
                return;

            if (branchDto.VillageId != 0 && branchDto.VillageId != null)
            {
                branch.ZoneID = (int)branchDto.VillageId;
            }
            else if (branchDto.CityId != 0 && branchDto.CityId != null)
            {
                branch.ZoneID = (int)branchDto.CityId;
            }
            else
            {
                // TODO: Throw Exception ;
            }
        }


        public async Task<ResultObject> DeleteBranchAsync(int Id)
        {
            ResultObject resultObject = new ResultObject();
            var userBranch = await _userService.GetUserBranchesByBranchIDAsync(Id);
            if (userBranch != null)
            {
                resultObject.ServerErrors.Add(new ServerErr() { Hint = "به دلیل وجود کاربر برای این شعبه اجازه ی حذف ندارید" });
                return resultObject;
            }
            await _branchService.DeleteBranchAsync(Id);
            await _transactionManager.SaveAllAsync();
            resultObject.Result = true;
            resultObject.ServerErrors = null;
            return resultObject;
        }

        public async Task<BranchDto> UpdateBranchAsync(BranchDto branchDto)
        {
            var branch = _mapper.Map<Branch>(branchDto);
            SetZoneIdForBranch(ref branchDto, ref branch);
            var branchTask = await _branchService.UpdateBranchAsync(branch);
            await _transactionManager.SaveAllAsync();
            var finalBranchDto = _mapper.Map<BranchDto>(branchTask);
            return finalBranchDto;
        }

    }
}
