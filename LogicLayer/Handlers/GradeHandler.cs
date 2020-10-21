using Api.Entities;
using System.Collections.Generic;

namespace LogicLayer.Handlers
{
    public class GradeHandler : BaseHandler<Grade, Db.Entities.Grade>
    {
        internal override Grade Convert(Db.Entities.Grade dbEntity)
        {
            return new Grade()
            {
                Id = dbEntity.Id,
                Class = new ClassHandler().Convert(dbEntity.Class),
            };
        }

        internal override Db.Entities.Grade Convert(Grade apiEntity)
        {
            return new Db.Entities.Grade()
            {
                Id = apiEntity.Id,
                Class = new ClassHandler().Convert(apiEntity.Class),
            };
        }
    }
}
