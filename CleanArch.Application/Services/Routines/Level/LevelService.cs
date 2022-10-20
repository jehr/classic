using Application.DTOs.Routines.Levels;
using Application.Interfaces.Routines.Level;
using Domain.Interfaces.Routines.Level;
using Domain.Models.Routine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Routines.Level
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }
        public async Task<List<LevelRoutines>> GetAll()
        {
            return await _levelRepository.Get().ToListAsync();
        }
    }
}
