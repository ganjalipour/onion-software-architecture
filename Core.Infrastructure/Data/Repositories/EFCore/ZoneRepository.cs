using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Data.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class ZoneRepository : EFCoreRepository<Zone>, IZoneRepository
    {
      //  private AppDBContext Context { set; get; }
        public ZoneRepository(IContextProviderFactory contextProvider) : base(contextProvider)
        {
          //  Context = context;
        }

        public async Task<IEnumerable<Zone>> GetProvince()
        {


            var provinces = Context.Zones.Where(z => z.SHAHRESTAN == null && z.BAKHSH == null && z.Dehestan == null && z.Abadi == null);


            var ostans = await provinces.ToListAsync();
            return ostans;

        }

        public async Task<IEnumerable<Zone>> GetAllCity()
        {
            var cities = await Context.Zones.Where(z => z.OSTAN != null && z.SHAHRESTAN != null && z.BAKHSH == null && z.Dehestan == null && z.Abadi == null).ToListAsync();
            List<Zone> zones = new List<Zone>();

            cities.ForEach(x => zones.Add(new Zone()
            {
                SHAHRESTAN = x.SHAHRESTAN,
                ShahrestName = x.ShahrestName,
                ID = x.ID,
                OSTAN = x.OSTAN,
                OstanName = x.OstanName
            }));
            return zones;
        }


        public async Task<IEnumerable<Zone>> GetCities(int provinceId)
        {
            string ostanCode = Context.Zones.Where(x => x.ID == provinceId).FirstOrDefault().OSTAN;

            var cities = Context.Zones.Where(x => x.OSTAN == ostanCode && x.SHAHRESTAN != null && x.BAKHSH == null);

            var cityList = await cities.ToListAsync();
            List<Zone> zones = new List<Zone>();

            cityList.ForEach(x => zones.Add(new Zone()
            {
                SHAHRESTAN = x.SHAHRESTAN,
                ShahrestName = x.ShahrestName,
                ID = x.ID,               
            }));

            return zones;
        }


        public async Task<IEnumerable<Zone>> GetVillages(int cityId)
        {
            var zone = Context.Zones.Where(x => x.ID == cityId).FirstOrDefault();
            string cityCode = zone.SHAHRESTAN;
            string provinceCode = zone.OSTAN;

            var villages = Context.Zones.Where(x => x.SHAHRESTAN == cityCode && x.OSTAN == provinceCode && x.BAKHSH != null && x.Dehestan != null && x.Abadi != null);

            var villagesList = await villages.ToListAsync();
            List<Zone> zones = new List<Zone>();

            villagesList.ForEach(x => zones.Add(new Zone() { Abadi = x.Abadi, AbadiName = x.AbadiName, ID = x.ID }));

            return zones;
        }

        public async Task<Zone> GetZoneInfoByZoneIDAsync(int zoneID)
        {
            var zone = await Context.Zones.FindAsync(zoneID);
            return zone;
        }

        public async Task<int> GetProvinceByCode(string oSTAN)
        {
            int ostanID = Context.Zones.Where(p => p.OSTAN == oSTAN && p.SHAHRESTAN == null).FirstOrDefault().ID;
            return ostanID;
        }

        public async Task<int> GetCityByCode(string oSTAN, string sHAHRESTAN)
        {
            int CityID = Context.Zones.Where(p => p.OSTAN == oSTAN && p.SHAHRESTAN == sHAHRESTAN && p.Abadi == null).FirstOrDefault().ID;
            return CityID;
        }

        public async Task<Zone> GetZoneByBranchIDAsync(int branchID)
        {
            var branch = await Context.Branches.Where(p => p.ID == branchID).Include(p => p.Zone)
                 .FirstOrDefaultAsync();
            return branch.Zone;
        }

        public async Task<List<Branch>> GetProvinceBranchesByProvinceCode(string ostanCode)
        {
            var branches = await (from branch in Context.Branches
                                  join zone in Context.Zones on branch.ZoneID equals zone.ID
                                  where zone.OSTANCode == ostanCode
                                  select branch).ToListAsync();

            return branches;

        }

    }

}
