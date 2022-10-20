using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Routines.Exercise;
using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Routines.Exercise
{
    public class ExerciseRepository : IExerciseRepository
    {
        private U27ApplicationDBContext _ctx;
        public ExerciseRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Exercises> Post(Exercises request)
        {
            try
            {
                _ctx.Exercises.Add(request);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("exercise", "No se ha guardado el ejercicio con exito");
            }

            return request;
        }
    }
}
