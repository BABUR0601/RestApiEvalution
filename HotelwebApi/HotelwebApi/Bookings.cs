using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomManagementSystem.Models;
using RoomManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bookings : ControllerBase
    {

        private readonly IBookingRepo _intrBook;

        public Bookings(IBookingRepo intrBook)
        {
            _intrBook = intrBook;
        }

        [HttpGet]
        public async Task<List<Booking>> getAllBooking()
        {
            return await _intrBook.getAllBooking();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] Booking rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrBook.AddBooking(rm);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdBooking([FromBody] Booking rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrBook.UpdBooking(rm);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteBooking(int id)
        {
            await _intrBook.DeleteBooking(id);
            return Ok();
        }

        [HttpGet("roomListBetween")]
        public async Task<List<int>> RoomBookedBetween()
        {
            return await _intrBook.RoomBookedBetween();
        }

    }
}
