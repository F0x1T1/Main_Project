using Main_Project.Interfaces;
using Main_Project.Models;

namespace Main_Project.Data
{
    public class VikladachRepository : Basic<Vikladach>, IVikladachrep
    {
        public VikladachRepository(AplContext context) : base(context)
        {

        }
    }
}
