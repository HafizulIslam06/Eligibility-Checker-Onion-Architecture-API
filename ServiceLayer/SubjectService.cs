using DomainLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository<Subject> _subjectRepository;

        public SubjectService(ISubjectRepository<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(int id)
        {
            await _subjectRepository.DeleteAsync(id);
        }
    }
}
