using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomManagementSystem.Models;
using RoomManagementSystem.Repository;
using RoomManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly ICategoryRepo _intrRoomCat;

        public Categories(ICategoryRepo intrRoom)
        {
            _intrRoomCat = intrRoom;
        }

        [HttpGet]
        public async Task<List<RoomCat>> getAllRoomsCat()
        {
            return await _intrRoomCat.getAllCategory();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomsCat([FromBody] RoomCat rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _intrRoomCat.AddCategory(rm);
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
        public async Task<IActionResult> UpdRoomsCat([FromBody] RoomCat rm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _intrRoomCat.UpdCategory(rm);
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
        public async Task<ActionResult<int>> DeleteRoomsCat(int id)
        {
            await _intrRoomCat.DeleteCategory(id);
            return Ok();
        }


        [HttpGet("getCatWiseAdvPaid")]

        public async Task<List<CatWiseRmBkdWithAdvView>> getCatWiseRoomBkdWithAdv()
        {
            return await _intrRoomCat.getCatWiseRoomBkdWithAdv();
        }


    }
}
