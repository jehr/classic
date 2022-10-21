using Domain.Models.Valoration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Valoration
{
    public class VModelValoration
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public Valorations Valoration { get; set; }
    }
}
