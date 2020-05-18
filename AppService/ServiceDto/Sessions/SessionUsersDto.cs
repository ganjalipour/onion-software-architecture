using System;
using Consulting.Domains.Core.Entities;

namespace Consulting.Applications.AppService.ServiceDto.SecurityDto
{
    public class SessionUsersDto
    {
        public SessionUsersDto()
        {
            this.Checked = false;
        }
        public int ID { get; set; }

        public int UserId { get; set; }

        public string NationalCode { get; set; }

        public string PhoneNumber { get; set; }

        public int SessionId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string SignaturePath { get; set; }

        public bool IsSignatory { get; set; }

        public bool IsDirector { get; set; }

        public bool Checked { get; set; }

    }
}
