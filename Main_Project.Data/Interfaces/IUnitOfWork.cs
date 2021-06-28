using System.Threading.Tasks;

namespace Main_Project.Interfaces
{
    public interface IUnitOfWork
    {
        IVikladachrep Vikladach { get; }
        IStudentrep Students { get; }
        ICoursesrep Courses { get; }
        Task SaveChangesAsync();
    }
}
