using Core.Models.Location;
using System;

namespace Application.DTOs.Location
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; } = true;
        public Guid StateId { get; set; }    
        public State State { get; set; }

    }
}
