using Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.HandlerInterfaces
{
    public interface IGradesHandler : IBasicHandler<Grade>
    {
        IEnumerable<Grade> GetStudentGrades(Guid studentId);
        IEnumerable<Grade> GetTeacherGrades(Guid teacherId);
    }
}
