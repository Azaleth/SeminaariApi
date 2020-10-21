using Api.Entities;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeminaariApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : BaseController, IBasicController<Student>
    {
        //internal StudentsController(SchoolDbContext context) : base(context) { }

        // GET api/Students
        [HttpGet]
        public IEnumerable<Student> Get() => HandlerFactory.StudentHandler.Get().Cast<Student>();

        // GET api/Students/5
        [HttpGet("{id}")]
        public Student Get(Guid id) => HandlerFactory.StudentHandler.Get(id) as Student;

        // POST api/Students
        [HttpPost]
        public void Post([FromBody] Student value) => HandlerFactory.StudentHandler.Add(value);

        // PUT api/Students/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Student value) => HandlerFactory.StudentHandler.Update(id, value);

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.StudentHandler.Delete(id);
    }
}
