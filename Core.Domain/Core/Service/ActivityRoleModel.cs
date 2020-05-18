using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domains.Core.Core.Service
{
  public  class ActivityRoleModel
    {
        public int ActivityID { get; set; }
        public string Title { get; set; }
        public int RoleID { get; set; }
        public long? RoleActivitiyID { get; set; }
        public bool HasAccess { get; set; }
    }
}
