using Consulting.Common.Constants;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Domains.Core.Service;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class BranchRepository : EFCoreRepository<Branch>, IBranchRepository
    {
    //    private AppDBContext Context { set; get; }

        private IConfiguration _configuration;
        private int _take;
        public BranchRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
          //  Context = context;
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }

        public async Task<Branch> GetBranchAsync(int id)
        {
            return await Context.Branches.FirstOrDefaultAsync(x => x.ID == id);
        }
        public void AddBranch(string name)
        {
            Context.Branches.Add(new Branch() { BranchName = name });
        }
        public Task<Branch> GetBranchAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultList> GetAllBranchAsync(BranchFilter filterDto)
        {
            var branches = await GetBranchesAsync(filterDto);
            return branches;
        }

        public async Task<Branch> GetBranchByCodeAsync(string branchCode)
        {
            return await Context.Branches.FirstOrDefaultAsync(x => x.BranchCode == branchCode);
        }

        private async Task<ResultList> GetBranchesAsync(BranchFilter branchFilter)
        {
            string provinceCode = string.Empty;
            string cityCode = string.Empty;
            string villageCode = string.Empty;

            if (branchFilter == null) branchFilter = new BranchFilter();


                if (branchFilter.ProvinceId != 0)
                    provinceCode = Context.Zones.Where(x => x.ID == branchFilter.ProvinceId).FirstOrDefault().OSTAN;

                if (branchFilter.CityId != 0)
                    cityCode = Context.Zones.Where(x => x.ID == branchFilter.CityId).FirstOrDefault().SHAHRESTAN;

                if (branchFilter.VillageId != 0)
                    villageCode = Context.Zones.Where(x => x.ID == branchFilter.VillageId).FirstOrDefault().Abadi;

            var branchesJoin = (from zone in Context.Zones
                                join branch in Context.Branches on zone.ID equals branch.ZoneID
                                select new BranchZoneJoinModel
                                {
                                    ID = branch.ID,
                                    BranchName = branch.BranchName,
                                    BranchCode = branch.BranchCode,
                                    OstanName = zone.OstanName,
                                    OSTAN = zone.OSTAN,
                                    ShahrestName = zone.ShahrestName,
                                    SHAHRESTAN = zone.SHAHRESTAN,
                                    BakhshName = zone.BakhshName,
                                    BAKHSH = zone.BAKHSH,
                                    DehestanName = zone.DehestanName,
                                    Dehestan = zone.Dehestan,
                                    AbadiName = zone.AbadiName,
                                    Abadi = zone.Abadi,
                                    ZoneID = zone.ID,
                                    Latitude = branch.Latitude,
                                    Longitude = branch.Longitude,
                                    BranchHeadName = branch.BranchHeadName,
                                    Fax = branch.Fax,
                                    PhoneNumber = branch.PhoneNumber,
                                    MeetingAddress1 = branch.MeetingAddress1,
                                    MeetingAddress2 = branch.MeetingAddress2,
                                    Address = branch.Address,
                                    BDN = branch.BDN,
                                    IsActive = branch.IsActive
                                }).AsQueryable()
                        .Where(x => branchFilter.ProvinceId == 0 || string.IsNullOrEmpty(provinceCode) || x.OSTAN == provinceCode)
                        .Where(x => branchFilter.CityId == 0 || string.IsNullOrEmpty(cityCode) || x.SHAHRESTAN == cityCode)
                        .Where(x => branchFilter.VillageId == 0 || string.IsNullOrEmpty(villageCode) || x.Abadi == villageCode)
                        .Where(x => string.IsNullOrEmpty(branchFilter.branchName) || x.BranchName.Contains(branchFilter.branchName))
                        .Where(x => string.IsNullOrEmpty(branchFilter.branchCode) || x.BranchCode.Contains(branchFilter.branchCode))
                        .Where(x => string.IsNullOrEmpty(branchFilter.BranchHeadName) || x.BranchHeadName.Contains(branchFilter.BranchHeadName))
                        .Where(x => string.IsNullOrEmpty(branchFilter.MeetingAddress1) || x.MeetingAddress1.Contains(branchFilter.MeetingAddress1))
                        .Where(x => string.IsNullOrEmpty(branchFilter.MeetingAddress2) || x.MeetingAddress2.Contains(branchFilter.MeetingAddress2))
                        .Where(x => string.IsNullOrEmpty(branchFilter.Fax) || x.Fax == branchFilter.Fax)
                        .Where(x => string.IsNullOrEmpty(branchFilter.PhoneNumber) || x.PhoneNumber == branchFilter.PhoneNumber)
                        .Where(x => string.IsNullOrEmpty(branchFilter.Address) || x.MeetingAddress2.Contains(branchFilter.Address));
                        



            var result = new ResultList();
            result.TotalRows = branchesJoin.Count();
            branchesJoin = ApplySorting(branchFilter, branchesJoin);
            if(branchFilter.PageNumber != 0)
            {
                branchesJoin = branchesJoin.Skip((branchFilter.PageNumber - 1) * _take).Take(_take);
            }
            result.MaxPageRows = _take;

            var branches = branchesJoin.Select(p => new Branch()
            {
                ID = p.ID,
                BranchName = p.BranchName,
                BranchCode = p.BranchCode,
                ZoneID = p.ZoneID,
                MasterAddress = p.OstanName + " " + p.ShahrestName + " " + p.AbadiName,
                Address = p.Address,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                BranchHeadName = p.BranchHeadName ,
                Fax = p.Fax , 
                BDN = p.BDN,
                IsActive = p.IsActive,
                MeetingAddress1 = p.MeetingAddress1 , 
                MeetingAddress2 = p.MeetingAddress2 ,
                PhoneNumber = p.PhoneNumber,
            });

            result.Results = await branches.ToListAsync();
            return result;
        }

        public async Task<ResultList> GetBranchListAsync(BranchFilter branchFilterDto)
        {
            ResultList resultList = new ResultList();
            IList<int> userBranches = new List<int>();
            if (branchFilterDto.UserID != ConstSpecialInfoes.SuperVisorAdmin)
                userBranches = await Context.UserBranches.Where(p => p.UserId == branchFilterDto.UserID)
                       .Select(p => p.BranchId).ToListAsync();

            var branches = await (from branch in Context.Branches
                                  where (branchFilterDto.UserID == ConstSpecialInfoes.SuperVisorAdmin ||
                                  userBranches.Contains(branch.ID))
                                  select branch).ToListAsync();
            resultList.Results = branches;
            return resultList;
        }

        public async Task<List<Branch>> GetUserBranches(int userID)
        {
            //var branchIDs = await (from userbranch in Context.UserBranches
            //                       where userbranch.UserId == userID
            //                       select userbranch.BranchId).ToListAsync();

            var branchList = await (from userbranch in Context.UserBranches
                                    join branch in Context.Branches on userbranch.BranchId equals branch.ID
                                    where userbranch.UserId == userID select branch) .ToListAsync();


            return branchList;
        }

        public class BranchZoneJoinModel
        {
            public int ID { get; set; }

            public int ZoneID { get; set; }

            public string BranchName { get; set; }

            public string BranchCode { get; set; }

            public string OSTAN { get; set; }

            public string OstanName { get; set; }

            public string SHAHRESTAN { get; set; }

            public string ShahrestName { get; set; }

            public string BAKHSH { get; set; }

            public string BakhshName { get; set; }

            public string Dehestan { get; set; }

            public string DehestanName { get; set; }

            public string Abadi { get; set; }

            public string AbadiName { get; set; }

            public string Latitude { get; set; }

            public string Longitude { get; set; }

            public string MeetingAddress1 { get; set; }

            public string MeetingAddress2 { get; set; }

            public string PhoneNumber { get; set; }
            public bool IsActive { get; set; }

            public string Fax { get; set; }
            public string BDN { get; set; }

            public string BranchHeadName { get; set; }

            public string Address { get; set; }

        }
    }
}
