using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.Models;
using RoomManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public class CategoryRepo : ICategoryRepo
    {

        private readonly hotelContext _db;

        public CategoryRepo(hotelContext db)
        {
            _db = db;
        }

        public async Task<int> AddCategory(RoomCat rmCat)
        {
            if (_db != null)

            {
                await _db.RoomCat.AddAsync(rmCat);
                await _db.SaveChangesAsync();
                return rmCat.CatId;
            }
            return 0;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var room = await _db.RoomCat.FirstOrDefaultAsync(x => x.CatId == id);
            if (room != null)
            {
                _db.RoomCat.Remove(room);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<List<RoomCat>> getAllCategory()
        {
            return await _db.RoomCat.ToListAsync();
        }

        public async Task UpdCategory(RoomCat rm)
        {
            _db.Entry(rm).State = EntityState.Modified;
            _db.RoomCat.Update(rm);
            await _db.SaveChangesAsync();
        }


        public async Task<List<CatWiseRmBkdWithAdvView>> getCatWiseRoomBkdWithAdv()
        {
            var obj = await (from cat in _db.RoomCat
                       join room in _db.EachRoom
                       on cat.CatId equals room.CatId
                       join booking in _db.Booking
                       on room.RoomNo equals booking.RoomNo
                       where booking.Advance > 0
                       select new
                       {
                           catId = cat.CatId,
                           roomNo = room.RoomNo,
                           catName = cat.TypeName,
                       }).ToListAsync();

                        var result = obj.GroupBy(x => x.catId);

            List<CatWiseRmBkdWithAdvView> results = new List<CatWiseRmBkdWithAdvView>();
            foreach(var catRm in result)
            {
                CatWiseRmBkdWithAdvView eachCat = new CatWiseRmBkdWithAdvView();
                eachCat.roomNo = new List<int>();
                eachCat.catId = catRm.Key;
                foreach (var room2 in catRm)
                {
                    eachCat.categoryName = room2.catName;
                    eachCat.roomNo.Add(room2.roomNo);
                }

                results.Add(eachCat);
            }


            return (results);
        }

    }
}
