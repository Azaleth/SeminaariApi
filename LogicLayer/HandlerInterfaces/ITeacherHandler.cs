using Api.Entities;
using System.Collections.Generic;

namespace LogicLayer.HandlerInterfaces
{
    public interface ITeacherHandler : IBasicHandler<Teacher>
    {
        IEnumerable<Class> GetClasses();
    }
}
