using Api.Entities;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.V1.Controllers
{
    public class StudentsController : BaseController, IBasicController<Student>
    {
        // GET api/Students
        [HttpGet]
        public IEnumerable<Student> Get(int skip = DEFAULT_SKIP, int take = DEFAULT_TAKE) => HandlerFactory.StudentHandler.Get(skip, take);

        // GET api/Students
        [HttpGet("{id}/Grades")]
        public IEnumerable<Grade> GetGrades(Guid id) => HandlerFactory.StudentHandler.GetGrades(id);

        // GET api/Students/5
        [HttpGet("{id}")]
        public Student Get(Guid id) => HandlerFactory.StudentHandler.Get(id);

        // POST api/Students
        [HttpPost]
        public Guid Post([FromBody] Student value) => HandlerFactory.StudentHandler.Add(value);

        // PUT api/Students/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Student value) => HandlerFactory.StudentHandler.Update(id, value);

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.StudentHandler.Delete(id);
    }
}
