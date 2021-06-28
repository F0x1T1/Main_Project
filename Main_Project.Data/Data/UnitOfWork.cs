using Main_Project.Interfaces;
using System.Threading.Tasks;

namespace Main_Project.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplContext aplContext;

        public UnitOfWork(AplContext aplContext, IVikladachrep Vikladach, IStudentrep student, ICoursesrep courses)
        {
            this.aplContext = aplContext;
            this.Vikladach = Vikladach;
            Students = student;
            Courses = courses;

        }

        public IVikladachrep Vikladach { get; }
        public IStudentrep Students { get; }
        public ICoursesrep Courses { get; }

        public async Task SaveChangesAsync()
        {
            await aplContext.SaveChangesAsync();
        }
       
    }
}
