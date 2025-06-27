using Microsoft.AspNetCore.Mvc;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISubjectService
    {
          Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectByID(int id);
    }
}
