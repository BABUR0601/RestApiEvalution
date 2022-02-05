using RoomManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public interface IBookingRepo
    {

        Task<List<Booking>> getAllBooking();
        Task<int> AddBooking(Booking rm);
        Task UpdBooking(Booking rm);
        Task<int> DeleteBooking(int id);
        Task<List<int>> RoomBookedBetween();

    }
}
