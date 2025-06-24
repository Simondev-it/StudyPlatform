using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SubjectService : ISubjectService
    {

        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Subject>> GetAllSujectsAsync()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
            return subjects;

        }
    }
}
