using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Location
{
    public class State : Entity
	{
		public string Name { get; set; }
        public string Code { get; set; }
		public bool Status { get; set; } = true;
		public Guid CountryId { get; set; }


		[ForeignKey("CountryId")]
		public Country Country { get; set; }

	}
}