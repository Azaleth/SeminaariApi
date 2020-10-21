using Api.Entities;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Collections.Generic;

namespace LogicLayer.Handlers
{
    public class ClassHandler : BaseHandler<Class, Db.Entities.Class>
    {
        internal override Class Convert(Db.Entities.Class dbEntity)
        {
            return new Class()
            {
                Id = dbEntity.Id,
                CourseCode = dbEntity.Identifier,
                Subject = dbEntity.Subject
            };
        }

        internal override Db.Entities.Class Convert(Class apiEntity)
        {
            return new Db.Entities.Class()
            {
                Id = apiEntity.Id,
                Identifier = apiEntity.CourseCode,
                Subject = apiEntity.Subject,
            };
        }
    }
}
