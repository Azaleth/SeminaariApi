using Api.Entities;
using System;
using System.Collections.Generic;

namespace LogicLayer.HandlerInterfaces
{
    public interface IStudentHandler : IBasicHandler<Student>
    {
        IEnumerable<Student> GetClassStudents(Guid classId);
    }
}
