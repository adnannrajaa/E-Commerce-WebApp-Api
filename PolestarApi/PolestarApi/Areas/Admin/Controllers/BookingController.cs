using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApi.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolestarApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BookingController(ApplicationDbContext db)
        {
            _db = db;
        }

        //HTTPGet : api/Booking

        [HttpGet]
        public ActionResult GetBooking()
        {
            JsonResult result = new JsonResult(new { });
            var booking = _db.Booking.Join(_db.UserAccount, b => b.UsersCustomerId, u => u.UserId, (b, u) => new { b, u })
               .Join(_db.BookingStatus, bs => bs.b.BookingStatusId, bss => bss.BookingStatusId, (bs, bss) => new { b = bs, bs = bss })
                .Select(bookings => new
                {
                    bookings.b.u.UserName,
                    bookings.b.u.Email,
                    bookings.b.b.BookingId,
                    bookings.b.b.BookingDate,
                    bookings.b.b.DeliveryDate,
                    bookings.b.b.TotalAmount,
                    bookings.b.b.BookingStatusId,
                    bookings.bs.Name
                }).ToList();

            if (booking == null)
            {
                return NotFound();
            }
            result.Value = new { Data = booking };
            return result;
        }

        //HTTPGet : api/Booking/5
        [HttpGet("{id}")]
        public ActionResult GetBookingDetails(int id)
        {
            JsonResult result = new JsonResult(new { });
            var bookingDetails = _db.BookingDetail.Find(id);

            if (bookingDetails == null)
            {
                return NotFound();
            }
            result.Value = new { Data = bookingDetails };
            return result;
        }
        //HTTPGet : api/Booking/4/2
        [HttpPut("{id}/{StatusID}")]
        public ActionResult PutBookingDetails(int id,int StatusID)
        {
            JsonResult result = new JsonResult(new { });
            var bookings = _db.Booking.Find(id);

            if (bookings == null)
            {
                return NotFound();
            }
            bookings.BookingStatusId = StatusID;
            _db.SaveChanges();
            result.Value = new { Data = true };
            return result;
        }

       

    }
}