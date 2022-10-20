using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Routine
{
    public class VModelRoutine
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public Routines Routine { get; set; }
    }
}
