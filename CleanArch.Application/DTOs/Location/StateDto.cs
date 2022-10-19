using Core.Models.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Location
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; } = true;
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
