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
    public class Rooms : ControllerBase
    {

        private readonly IRoomRepo _intrRoom;

        public Rooms(IRoomRepo intrRoom)
        {
            _intrRoom = intrRoom;
        }

        [HttpGet]
        public async Task<List<EachRoom>> getAllRooms()
        {
            return await _intrRoom.getAllRooms();
        }

        [HttpPost]
        public async Task<IActionResult> AddRooms([FromBody] EachRoom rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrRoom.AddRooms(rm);
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
        public async Task<IActionResult> UpdRooms([FromBody] EachRoom rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrRoom.UpdRooms(rm);
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
        public async Task<ActionResult<int>> DeleteRooms(int id)
        {
            await _intrRoom.DeleteRooms(id);
            return Ok();
        }




    }
}
