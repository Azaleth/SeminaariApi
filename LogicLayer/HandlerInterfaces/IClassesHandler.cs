using Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.HandlerInterfaces
{
    public interface IClassesHandler : IBasicHandler<Class>
    {
        IEnumerable<Class> GetStudentClasses(Guid teacherId);
        IEnumerable<Class> GetTeacherClasses(Guid teacherId);
    }
}
