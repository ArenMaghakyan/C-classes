﻿using System.Collections.Generic;
using TrainingsSystemAT.DAL.Models;

namespace TrainingsSystemAT.DAL.RepositoriesAPI
{
    public interface IDisciplinesRepository
    {
        Dictionary<string, List<Person>> GetPersonsPerDiscipline(int roleId);
    }
}
