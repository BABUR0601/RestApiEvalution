using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public class RoomRepo : IRoomRepo
    {

        private readonly hotelContext _db;

        public RoomRepo(hotelContext db)
        {
            _db = db;
        }

        public async Task<int> AddRooms(EachRoom rm)
        {
            if (_db != null)

            {
                await _db.EachRoom.AddAsync(rm);
                await _db.SaveChangesAsync();
                return rm.RoomNo;
            }
            return 0;
        }

        public async Task<int> DeleteRooms(int id)
        {
            var room = await _db.EachRoom.FirstOrDefaultAsync(x => x.RoomNo == id);
            if (room != null)
            {
                _db.EachRoom.Remove(room);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<List<EachRoom>> getAllRooms()
        {
            return await _db.EachRoom.ToListAsync();
        }

        public async Task UpdRooms(EachRoom rm)
        {
            _db.Entry(rm).State = EntityState.Modified;
            _db.EachRoom.Update(rm);
            await _db.SaveChangesAsync();
        }
    }
}
