using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GymApplication_new.Models;

namespace GymApplication_new.Controllers
{
    public class WeekdayDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WeekdayData/ListWeekdays
        [HttpGet]
        public IEnumerable<WeekdayDto> ListWeekdays()
        {
            List<Weekday> Weekdays= db.Weekdays.ToList();
            List<WeekdayDto> WeekdayDtos = new List<WeekdayDto>();

            Weekdays.ForEach(a => WeekdayDtos.Add(new WeekdayDto()
            {
                WeekdayId = a.WeekdayId,
                WeekdayName = a.WeekdayName
            }));

            return WeekdayDtos;

        }

        // GET: api/WeekdayData/FindWeekday/5
        [ResponseType(typeof(Weekday))]
        [HttpGet]
        public IHttpActionResult FindWeekday(int id)
        {
            Weekday Weekday = db.Weekdays.Find(id);
            WeekdayDto WeekdayDto = new WeekdayDto()
            {
                WeekdayId = Weekday.WeekdayId,
                WeekdayName = Weekday.WeekdayName
            };
            if (Weekday == null)
            {
                return NotFound();
            }

            return Ok(WeekdayDto);
        }

        // PUT: api/WeekdayData/UpdateAnimal/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateWeekday(int id, Weekday weekday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weekday.WeekdayId)
            {
                return BadRequest();
            }

            db.Entry(weekday).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeekdayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WeekdayData/AddAnimal
        [ResponseType(typeof(Weekday))]
        [HttpPost]
        public IHttpActionResult AddWeekday(Weekday weekday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Weekdays.Add(weekday);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = weekday.WeekdayId }, weekday);
        }

        // DELETE: api/WeekdayData/DeleteWeekday/5
        [ResponseType(typeof(Weekday))]
        [HttpPost]
        public IHttpActionResult DeleteWeekday(int id)
        {
            Weekday weekday = db.Weekdays.Find(id);
            if (weekday == null)
            {
                return NotFound();
            }

            db.Weekdays.Remove(weekday);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeekdayExists(int id)
        {
            return db.Weekdays.Count(e => e.WeekdayId == id) > 0;
        }
    }
}