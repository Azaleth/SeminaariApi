using Api.Entities;
using LogicLayer.HandlerInterfaces;
using LogicLayer.Handlers;

namespace LogicLayer
{
    public class HandlerFactory
    {
        public IStudentHandler StudentHandler => new StudentHandler();
        public ITeacherHandler TeacherHandler => new TeacherHandler();
        public IBasicHandler<Class> ClassHandler => new ClassHandler();
        public IBasicHandler<Grade> GradeHandler => new GradeHandler();
    }
}
