using Api.Entities;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SeminaariApi.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : BaseController, IBasicController<Teacher>
    {
        //internal TeachersController(SchoolDbContext context) : base(context) { }
        // GET api/Teachers
        [HttpGet]
        public IEnumerable<Teacher> Get() => HandlerFactory.TeacherHandler.Get();

        // GET api/Teachers/5
        [HttpGet("{id}")]
        public Teacher Get(Guid id) => HandlerFactory.TeacherHandler.Get(id);

        // POST api/Teachers
        [HttpPost]
        public void Post([FromBody] Teacher value) => HandlerFactory.TeacherHandler.Add(value);

        // PUT api/Teachers/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Teacher value) => HandlerFactory.TeacherHandler.Update(id, value);

        // DELETE api/Teachers/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.TeacherHandler.Delete(id);
    }
}
