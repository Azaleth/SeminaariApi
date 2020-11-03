using Api.Entities;
using LogicLayer.HandlerInterfaces;
using LogicLayer.Handlers;

namespace LogicLayer
{
    public class HandlerFactory
    {
        public IStudentHandler StudentHandler => new StudentHandler();
        public ITeacherHandler TeacherHandler => new TeacherHandler();
        public IClassesHandler ClassHandler => new ClassHandler();
        public IGradesHandler GradeHandler => new GradeHandler();
    }
}
