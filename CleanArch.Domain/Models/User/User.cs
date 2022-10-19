using Core.Models.Common;
using System.Collections.Generic;



namespace Domain.Models.User
{
    public class User : Entity
	{
		public string Document { get; set; }
        public string Names { get; set; }
        public string CampaignName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;    
        public string PassWord { get; set; } 
        public string login { get; set; }       
        public List<UserRol> UserRol { get; set; }

    }
}