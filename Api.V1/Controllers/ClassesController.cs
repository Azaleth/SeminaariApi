using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.V1.Controllers
{
    public class ClassesController : BaseController, IBasicController<Class>
    {
        // GET api/Classs
        [HttpGet]
        public IEnumerable<Class> Get(int skip = DEFAULT_SKIP, int take = DEFAULT_TAKE) => HandlerFactory.ClassHandler.Get(skip, take);

        // GET api/Classs/5
        [HttpGet("{id}")]
        public Class Get(Guid id) => HandlerFactory.ClassHandler.Get(id);

        // POST api/Classs
        [HttpPost]
        public Guid Post([FromBody] Class value) => HandlerFactory.ClassHandler.Add(value);

        // PUT api/Classs/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Class value) => HandlerFactory.ClassHandler.Update(id, value);

        // DELETE api/Classs/5
        [HttpDelete("{id}")]
        public void Delete(Guid id) => HandlerFactory.ClassHandler.Delete(id);
    }
}
