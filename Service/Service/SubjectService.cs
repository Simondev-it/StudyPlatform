using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Subject> AddSubject(Subject subject)
        {
            subject.UploadDate = subject.LastEditDate = DateOnly.FromDateTime(DateTime.Now);
            return await _unitOfWork.SubjectRepository.AddSubject(subject);
        }

        public async Task<bool> DeleteSubject(int id)
        {
            return await _unitOfWork.SubjectRepository.DeleteSubject(id);
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _unitOfWork.SubjectRepository.GetAllSubjects();
        }

        public async Task<Subject> GetSubjectByID(int id)
        {
            return await _unitOfWork.SubjectRepository.GetSubjectsById(id);
        }

        public async Task<bool> UpdateSubject(Subject subject)
        {
            return await _unitOfWork.SubjectRepository.UpdateSubject(subject);
        }

        //public async Task<List<Subject>> GetAllSubjects()
        //{
        //    return await _unitOfWork.SubjectRepository.GetAllAsync(
        //          includes: new Expression<Func<Subject, object>>[]
        //{
        //    s => s.Chapters,
        // }
        //    );


        //}
    }
    }
