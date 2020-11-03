using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.V1.Controllers
{
    public class GradesController : BaseController, IBasicController<Grade>
    {
        // GET api/Grades
        [HttpGet]
        public IEnumerable<Grade> Get(int skip = DEFAULT_SKIP, int take = DEFAULT_TAKE) => HandlerFactory.GradeHandler.Get(skip, take);

        // GET api/Grades/5
        [HttpGet("{id}")]
        public Grade Get(Guid id) => HandlerFactory.GradeHandler.Get(id);        

        // POST api/Grades
        [HttpPost]
        public Guid Post([FromBody] Grade value) => HandlerFactory.GradeHandler.Insert(value);

        // PUT api/Grades/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Grade value) => HandlerFactory.GradeHandler.Update(id, value);

        // DELETE api/Grades/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.GradeHandler.Delete(id);
    }
}
