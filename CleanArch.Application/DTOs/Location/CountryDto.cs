using System;

namespace Application.DTOs.Location
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; } = true;
    }
}
