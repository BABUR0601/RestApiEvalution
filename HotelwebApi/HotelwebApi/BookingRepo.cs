using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public class BookingRepo : IBookingRepo
    {

        private readonly hotelContext _db;

        public BookingRepo(hotelContext db)
        {
            _db = db;
        }

        public async Task<int> AddBooking(Booking book)
        {
            if (_db != null)

            {
                await _db.Booking.AddAsync(book);
                await _db.SaveChangesAsync();
                return book.BookId;
            }
            return 0;
        }

        public async Task<int> DeleteBooking(int id)
        {
            var room = await _db.Booking.FirstOrDefaultAsync(x => x.BookId == id);
            if (room != null)
            {
                _db.Booking.Remove(room);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<List<Booking>> getAllBooking()
        {
            return await _db.Booking.ToListAsync();
        }

        public async Task<List<int>> RoomBookedBetween()
        {
            var results = await (from book in _db.Booking
                                 where book.DateOfBook > new DateTime(2021, 10, 20).Date && (((DateTime)book.DateOfBook).AddDays(10)).Date < new DateTime(2021, 10, 23).Date
                                 select book).ToListAsync();

            List<int> returnList = new List<int>();
            foreach(var result in results)
            {
                returnList.Add((int)result.RoomNo);
            }

            return returnList;


        }

        public async Task UpdBooking(Booking rm)
        {
            _db.Entry(rm).State = EntityState.Modified;
            _db.Booking.Update(rm);
            await _db.SaveChangesAsync();
        }
    }
}
