using Api.Entities;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.V1.Controllers
{
    public class TeachersController : BaseController, IBasicController<Teacher>
    {
        // GET api/Teachers
        [HttpGet]
        public IEnumerable<Teacher> Get(int skip = DEFAULT_SKIP, int take = DEFAULT_TAKE) => HandlerFactory.TeacherHandler.Get(skip, take);

        // GET api/Teachers/5
        [HttpGet("{id}")]
        public Teacher Get(Guid id) => HandlerFactory.TeacherHandler.Get(id);

        // GET api/Teachers/5/Classes
        [HttpGet("{id}/Classes")]
        public IEnumerable<Class> GetClasses(Guid id) => HandlerFactory.ClassHandler.GetTeacherClasses(id);

        // POST api/Teachers
        [HttpPost]
        public Guid Post([FromBody] Teacher value) => HandlerFactory.TeacherHandler.Insert(value);

        // PUT api/Teachers/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Teacher value) => HandlerFactory.TeacherHandler.Update(id, value);

        // DELETE api/Teachers/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.TeacherHandler.Delete(id);
    }
}
