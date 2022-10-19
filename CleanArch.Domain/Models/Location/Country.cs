using Core.Models.Common;

namespace Core.Models.Location
{
    public class Country : Entity
	{
		public string Name { get; set; }
		public bool Status { get; set; } = true;

	}
}