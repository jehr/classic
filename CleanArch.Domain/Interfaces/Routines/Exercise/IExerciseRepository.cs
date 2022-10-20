using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Routines.Exercise
{
    public interface IExerciseRepository
    {
        Task<Exercises> Post(Exercises request);
    }
}
