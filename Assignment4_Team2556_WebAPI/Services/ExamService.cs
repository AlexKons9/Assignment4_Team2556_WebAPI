using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;
using NuGet.Protocol.Core.Types;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class ExamService : IGenericService<Exam>
    {
        public IGenericRepository<Exam> _repository { get; set; }

        public ExamService(IGenericRepository<Exam> repository)
        {
            _repository = repository;
        }

        public async Task<Exam> AddOrUpdateAsync(Exam exam)
        {
            return await _repository.AddOrUpdateAsync(exam);
        }

        public async Task<IList<Exam>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Exam?> GetAsync(int? id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<bool> RemoveAsync(Exam exam)
        {
            return await _repository.RemoveAsync(exam);
        }
    }
}
