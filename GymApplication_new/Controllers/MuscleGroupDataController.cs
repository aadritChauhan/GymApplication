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
    public class MuscleGroupDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MuscleGroupData/ListMuscleGroups
        [HttpGet]
        public IEnumerable<MuscleGroupDto> ListMuscleGroups()
        {
            List<MuscleGroup> MuscleGroups= db.MuscleGroups.ToList();
            List<MuscleGroupDto> MuscleGroupDtos = new List<MuscleGroupDto>();

            MuscleGroups.ForEach(a => MuscleGroupDtos.Add(new MuscleGroupDto() {
                MuscleGroupId= a.MuscleGroupId,
                MuscleGroupName = a.MuscleGroupName,
                Exercises= a.Exercises
            }));
            return MuscleGroupDtos;
        }

        // GET: api/MuscleGroupData/FindMuscleGroup/5
        [ResponseType(typeof(MuscleGroup))]
        [HttpGet]
        public IHttpActionResult FindMuscleGroup(int id)
        {
            MuscleGroup MuscleGroup = db.MuscleGroups.Find(id);
            MuscleGroupDto MuscleGroupDto = new MuscleGroupDto()
            {
                MuscleGroupId= MuscleGroup.MuscleGroupId,
                MuscleGroupName= MuscleGroup.MuscleGroupName,
                Exercises= MuscleGroup.Exercises
            };
            if (MuscleGroup == null)
            {
                return NotFound();
            }
            
            return Ok(MuscleGroupDto);
        }

        // POST: api/MuscleGroupData/UpdateMuscleGroup/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateMuscleGroup(int id, MuscleGroup muscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muscleGroup.MuscleGroupId)
            {
                return BadRequest();
            }

            db.Entry(muscleGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleGroupExists(id))
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

        // POST: api/MuscleGroupData/AddMuscleGroup
        [ResponseType(typeof(MuscleGroup))]
        [HttpPost]
        public IHttpActionResult AddMuscleGroup(MuscleGroup muscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MuscleGroups.Add(muscleGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = muscleGroup.MuscleGroupId }, muscleGroup);
        }

        // POST: api/MuscleGroupData/DeleteMuscleGroup/5
        [ResponseType(typeof(MuscleGroup))]
        [HttpPost]
        public IHttpActionResult DeleteMuscleGroup(int id)
        {
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            db.MuscleGroups.Remove(muscleGroup);
            db.SaveChanges();

            return Ok(muscleGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MuscleGroupExists(int id)
        {
            return db.MuscleGroups.Count(e => e.MuscleGroupId == id) > 0;
        }
    }
}