using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.MongoDb;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.CoreContext;
using Consulting.Infrastructure.Core.Data.Repositories.MongoDbManagment;
using Consulting.Infrastructure.Data.Repositories.MongoDbManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Consulting.Infrastructure.Data.Repositories.EFCore
{
    public class TransactionManager : ITransactionManager
    {
        private AppDBContext Context { set; get; }
        private int currentUserId;
        private readonly AuditLogRepository auditLogRepository;
        private MongoDBManager mongoManager;
        List<AuditLog> auditLogList;
        public TransactionManager(IContextProviderFactory contextProvider, UserResolverService userService, MongoDBManager _mongoManager
            , AuditLogRepository _auditLogRepository)
        {
            //Context = context;
            Context = contextProvider.dbContext;
            auditLogRepository = _auditLogRepository;
            mongoManager = _mongoManager;
            currentUserId = userService.GetCurrentUser();
        }

        public async Task<int> SaveAllAsync()
        {
            AddTimestamps();

            auditLogList = new List<AuditLog>();
            var addedChangeInfo = Context.ChangeTracker.Entries()
                               .Where(t => t.State == EntityState.Added).ToList();

            var modifiedChangeInfo = Context.ChangeTracker.Entries()
                               .Where(t => t.State == EntityState.Modified || t.State == EntityState.Deleted).ToList();

            AddAuditLogs(modifiedChangeInfo);

            var result = await Context.SaveChangesAsync();
            if (result > 0)
            {
                AddAuditLogs(addedChangeInfo);
                //auditLogRepository.InsertMany(auditLogList);
            }
            return result;           
        }

        private void AddAuditLogs(List<EntityEntry> entityEntries)
        {
            foreach (var item in entityEntries)
            {
                AuditLog auditLog = new AuditLog()
                {
                    EntityID = item.Entity.GetType().GetProperty("ID") == null ? (int)item.Property("Id").CurrentValue : (int)item.Property("ID").CurrentValue,
                    ObjectType = item.Entity.GetType().Name,
                    OccurrenceDate = DateTime.Now,
                    UserID = currentUserId
                }; 
                if (item.State == EntityState.Modified)
                {
                    auditLog.ActionTitle = "Edit";
                    auditLog.BeforeChanged = item.OriginalValues.ToObject();
                    auditLog.AfterChanged = item.CurrentValues.ToObject();
                }
                else if (item.State == EntityState.Deleted)
                {
                    auditLog.ActionTitle = "Delete";
                    auditLog.BeforeChanged = item.OriginalValues.ToObject();
                    auditLog.AfterChanged = null;
                }
                // added 
                else
                {
                    auditLog.ActionTitle = "Add";
                    auditLog.BeforeChanged = null;
                    auditLog.AfterChanged = item.OriginalValues.ToObject();
                }

                auditLogList.Add(auditLog);
            }
        }

        private async Task AddAutoSerials(List<EntityEntry> entities)
        {
            if (entities.Count > 0)
            {
                int counter = 0;
                int maxSerial = 0;

                foreach (var item in entities)
                {
                     if (item.Entity is Branch)
                    {
                        var branch = item.Entity as Branch;
                        var zone = await Context.Zones.FirstOrDefaultAsync(p => p.ID == branch.ZoneID);
                        if (zone != null)
                        {
                            branch.OSTANCode = zone.OSTANCode;
                            var rows = Context.Branches.Where(p => p.OSTANCode == zone.OSTANCode).OrderByDescending(p => p.Serial);
                            if (rows.Any())
                                maxSerial = rows.Max(p => p.Serial);
                            branch.Serial = maxSerial + 1;
                            branch.BranchCode = branch.OSTANCode + branch.Serial.ToString().PadLeft(4, '0');
                        }
                    }

                }
                await Context.SaveChangesAsync();
            }
        }

        private void AddTimestamps()
        {
            var entities = Context.ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added
            || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("CreateDate").CurrentValue = DateTime.Now;
                    entity.Property("CreatedBy").CurrentValue = currentUserId;
                }
                else
                {
                    entity.Property("UpdateDate").CurrentValue = DateTime.Now;
                    entity.Property("ModifiedBy").CurrentValue = currentUserId;
                }
            }
        }
    }

}
