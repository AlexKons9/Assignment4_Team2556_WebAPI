using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class ExamRepository : IGenericRepository<Exam>
    {
        public Task<Exam> AddOrUpdateAsync(Exam entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Exam>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exam?> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Exam entity)
        {
            throw new NotImplementedException();
        }
    }
}
