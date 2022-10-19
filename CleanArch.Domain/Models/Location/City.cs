using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Location
{
    public class City : Entity
	{
		public string Name { get; set; }
		public string Code { get; set; }
        public bool Status { get; set; } = true;
		public Guid StateId { get; set; }


		[ForeignKey("StateId")]
		public State State  { get; set; }

	}
}