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
    public class CourseController : ControllerBase
    {

        ITIDBContext db;
        private readonly IMapper mapper;

        public CourseController(ITIDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = mapper.Map<IEnumerable<CourseDTO>>(db.courses.Include(c => c.Topic).ToList());
            return Ok(courses);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == null)
                return BadRequest();

            Course course = db.courses.Include(c => c.Topic).SingleOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound();

            return Ok(mapper.Map<CourseDTO>(course));
        }

        [HttpPost]
        public IActionResult Create(CourseDTO data)
        {
            if (data == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Course course = mapper.Map<Course>(data);

            db.courses.Add(course);
            db.SaveChanges();

            return CreatedAtAction("GetById", new { Id = course.Id }, mapper.Map<CourseDTO>(course));
        }



        [HttpPut]
        public IActionResult Update([FromBody] CourseDTO data)
        {
            if (data == null || data?.Id == 0)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Course founded = db.courses.Find(data?.Id);

            if (founded == null)
                return NotFound();

            Course course = mapper.Map<Course>(data);

            db.Entry(course).State = EntityState.Modified;
            //db.Update(course);

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            Course founded = db.courses.Find(id);

            if (founded == null)
                return NotFound();

            db.courses.Remove(founded);

            db.SaveChanges();

            return NoContent();

        }

    }
}
