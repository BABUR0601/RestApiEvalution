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
    public class Customers : ControllerBase
    {
        private readonly ICustomerRepo _intrRoom;

        public Customers(ICustomerRepo intrRoom)
        {
            _intrRoom = intrRoom;
        }

        [HttpGet]
        public async Task<List<Customer>> getAllCustomers()
        {
            return await _intrRoom.getAllCustomer();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] Customer rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrRoom.AddCustomer(rm);
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
        public async Task<IActionResult> UpdCustomers([FromBody] Customer rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrRoom.UpdCustomer(rm);
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
        public async Task<ActionResult<int>> DeleteCustomers(int id)
        {
            await _intrRoom.DeleteCustomer(id);
            return Ok();
        }



    }
}
