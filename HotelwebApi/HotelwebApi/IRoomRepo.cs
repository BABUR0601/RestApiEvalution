using RoomManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public interface IRoomRepo
    {

        Task<List<EachRoom>> getAllRooms();
        Task<int> AddRooms(EachRoom rm);
        Task UpdRooms(EachRoom rm);
        Task<int> DeleteRooms(int id);

    }
}
