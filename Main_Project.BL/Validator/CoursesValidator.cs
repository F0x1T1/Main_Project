using FluentValidation;
using Main_Project.BL.DTO;

namespace Main_Project.BL.Validator
{
    public class CoursesValidator : AbstractValidator<PostCoursesDTO>
    {
        public CoursesValidator()
        {
            RuleFor(x => x.CoursesID).NotEmpty();
            RuleFor(x => x.NameCourses).NotEmpty().Length(3, 45); 
        }
    }
    
}
