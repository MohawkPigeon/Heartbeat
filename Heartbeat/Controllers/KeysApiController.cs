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
using System.Web.Mvc;
using Heartbeat.Data;
using Heartbeat.Models;
using System.Web.Http.Cors;


namespace Heartbeat.Controllers
{
    public class KeysApiController : ApiController
    {
        private HeartbeatContext db = new HeartbeatContext();

        // GET: api/KeysApi
        [EnableCors(origins: "*",headers:"*",methods:"*")]
        public IHttpActionResult GetKeys()
        {
            List<KeyDTO> keyDTOs = new List<KeyDTO>();
            foreach (var item in db.Keys)
            {
                KeyDTO keyDTO = new KeyDTO();
                keyDTO.latitude = item.latitude;
                keyDTO.longitude = item.longitude;
                keyDTO.name = item.name;
                keyDTOs.Add(keyDTO);
            }

            return Ok(keyDTOs);
        }
        

        // GET: api/KeysApi/5
        [ResponseType(typeof(Key))]
        public IHttpActionResult GetKey(int id)
        {
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return NotFound();
            }

            return Ok(key);
        }

        // PUT: api/KeysApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKey(int id, Key key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != key.KeyID)
            {
                return BadRequest();
            }

            db.Entry(key).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyExists(id))
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

        // POST: api/KeysApi
        [ResponseType(typeof(Key))]
        public IHttpActionResult PostKey(Key key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keys.Add(key);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = key.KeyID }, key);
        }

        // DELETE: api/KeysApi/5
        [ResponseType(typeof(Key))]
        public IHttpActionResult DeleteKey(int id)
        {
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return NotFound();
            }

            db.Keys.Remove(key);
            db.SaveChanges();

            return Ok(key);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyExists(int id)
        {
            return db.Keys.Count(e => e.KeyID == id) > 0;
        }
    }
}