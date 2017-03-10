using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApartmentFinderDAL;
using MOD = ApartmentFinderWebAPI.Models;

namespace ApartmentFinderWebAPI.Controllers
{
    public class ApartmentsController : ApiController
    {
        private ApartmentFinderEntities db = new ApartmentFinderEntities();

        // GET: api/Apartments
        public IEnumerable<MOD.Apartment> GetApartments()
        {
            List<MOD.Apartment> apartmentList = new List<MOD.Apartment>();
            foreach (var item in db.Apartments)
                {
                apartmentList.Add(ConvertEntityToModel.convertApartment(item));
                }
            return apartmentList;
        }
        [ActionName("GetApartmentsByAddress")]
        public IEnumerable<MOD.Apartment> GetApartmentsByAddress(string address)
        {
            List<MOD.Apartment> apartmentList = new List<MOD.Apartment>();
            foreach (var item in db.Apartments)
            {
                if (address.Contains(item.City.Zip_Code))
                {
                    apartmentList.Add(ConvertEntityToModel.convertApartment(item));
                }else if(address.Contains(item.City.Name) && address.Contains(item.City.State.StateName))
                {
                    apartmentList.Add(ConvertEntityToModel.convertApartment(item));
                }

            }
            return apartmentList;
        }
        [ActionName("GetAvailableApartmentsByAddress")]
        public IEnumerable<MOD.Apartment> GetAvailableApartmentsByAddress(string address)
        {
            List<MOD.Apartment> apartmentList = new List<MOD.Apartment>();
            foreach (var item in db.Apartments)
            {
                MOD.Apartment tempApartment = new MOD.Apartment();
                if (address.Contains(item.City.Zip_Code)|| address.Contains(item.City.Name) && address.Contains(item.City.State.StateName))
                {
                    tempApartment = ConvertEntityToModel.convertApartment(item);
                    List<MOD.Room>tempRoomList = tempApartment.RoomList;
                    for (int i = 0; i < tempApartment.RoomList.Count; i++)
                    {
                        if (tempApartment.RoomList[i].IsFilled)
                        {
                            tempApartment.RoomList.Remove(tempApartment.RoomList[i]);
                        }
                    }
    
                        if (tempApartment.RoomList.Count>0)
                    {
                        apartmentList.Add(tempApartment);
                    }
                    
                }
            }


            return apartmentList;
        }

        // GET: api/Apartments/
        [ResponseType(typeof(Apartment))]

        public async Task<IHttpActionResult> GetApartment(int id)
        {
            // Is it a zip or a city

            // if city do this
            Apartment apartment = await db.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        // PUT: api/Apartments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApartment(int id, Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartment.ApartmentID)
            {
                return BadRequest();
            }

            db.Entry(apartment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(id))
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

        // POST: api/Apartments
        [ResponseType(typeof(Apartment))]
        public async Task<IHttpActionResult> PostApartment(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartments.Add(apartment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = apartment.ApartmentID }, apartment);
        }

        // DELETE: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public async Task<IHttpActionResult> DeleteApartment(int id)
        {
            Apartment apartment = await db.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }

            db.Apartments.Remove(apartment);
            await db.SaveChangesAsync();

            return Ok(apartment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool ApartmentExists(int id)
        {
            return db.Apartments.Count(e => e.ApartmentID == id) > 0;
        }
    }
}