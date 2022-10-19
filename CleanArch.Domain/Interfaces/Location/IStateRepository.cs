﻿using Core.Models.Location;
using System.Linq;

namespace Domain.Interfaces.Location
{
    public interface IStateRepository
    {
        IQueryable<State> GetAll();

    }
}
