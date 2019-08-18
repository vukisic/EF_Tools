using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Classes;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper mapper;

        public ValuesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var source = new ToDoItem() { Name = "Alabama" };
            var destination = mapper.Map<ToDoItemResponse>(source);
            return destination.Name;
        }

        
    }
}
