using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLabs.DTO;
using WebApiLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        ITIDBContext db;
        private readonly IMapper mapper;

        public TopicController(ITIDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var topics = mapper.Map<IEnumerable<TopicDTO>>(db.topics.Include(t => t.Courses).ToList());
            return Ok(topics);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == null)
                return BadRequest();

            Topic topic = db.topics.Include(t => t.Courses).SingleOrDefault(t => t.Id == id);

            if (topic == null)
                return NotFound();

            return Ok(mapper.Map<TopicDTO>(topic));
        }

        [HttpPost]
        public IActionResult Create(TopicDTO data)
        {
            if (data == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Topic topic = mapper.Map<Topic>(data);

            db.topics.Add(topic);
            db.SaveChanges();

            return CreatedAtAction("GetById", new { Id = topic.Id }, mapper.Map<Topic>(topic));
        }



        [HttpPut]
        public IActionResult Update([FromBody] TopicDTO data)
        {
            if (data == null || data?.Id == 0)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Topic founded = db.topics.Find(data?.Id);

            if (founded == null)
                return NotFound();

            Topic topic = mapper.Map<Topic>(data);

            db.Entry(topic).State = EntityState.Modified;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            Topic founded = db.topics.Find(id);

            if (founded == null)
                return NotFound();

            db.topics.Remove(founded);

            db.SaveChanges();

            return NoContent();
        }

    }
}
