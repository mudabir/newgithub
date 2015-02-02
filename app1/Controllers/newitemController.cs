using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using app1.Models;

namespace app1.Controllers
{
    public class newitemController : ApiController
    {
        private new_itemContext db = new new_itemContext();

        // GET api/newitem
        public IEnumerable<Item> GetItems()
        {
            return db.Items.AsEnumerable();
        }

        // GET api/newitem/5
        public Item GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return item;
        }

        // PUT api/newitem/5
        public HttpResponseMessage PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != item.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/newitem
        public HttpResponseMessage PostItem(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/newitem/5
        public HttpResponseMessage DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Items.Remove(item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}