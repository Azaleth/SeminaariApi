using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.V1.Controllers
{
    public class ClassesController : BaseController, IBasicController<Class>
    {
        // GET api/Classes
        [HttpGet]
        public IEnumerable<Class> Get(int skip = DEFAULT_SKIP, int take = DEFAULT_TAKE) => HandlerFactory.ClassHandler.Get(skip, take);

        // GET api/Classes/5
        [HttpGet("{id}")]
        public Class Get(Guid id) => HandlerFactory.ClassHandler.Get(id);

        // GET api/Classes/5/Students
        [HttpGet("{id}/Students")]
        public IEnumerable<Student> GetStudents(Guid id) => HandlerFactory.StudentHandler.GetClassStudents(id);

        // POST api/Classes
        [HttpPost]
        public Guid Post([FromBody] Class value) => HandlerFactory.ClassHandler.Insert(value);

        // PUT api/Classes/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Class value) => HandlerFactory.ClassHandler.Update(id, value);

        // DELETE api/Classes/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.ClassHandler.Delete(id);

        // GET api/Classes/Throw
        [HttpGet("Throw")]
        public void Throw() => throw new NotImplementedException("this is not implemented");
    }
}
