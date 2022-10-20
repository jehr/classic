using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Exercise
{
    public class VModelResponseExercise
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public Exercises Exercise { get; set; }
    }
}
