using RoomManagementSystem.Models;
using RoomManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public interface ICategoryRepo
    {

        Task<List<RoomCat>> getAllCategory();
        Task<int> AddCategory(RoomCat rm);
        Task UpdCategory(RoomCat rm);
        Task<int> DeleteCategory(int id);
        Task<List<CatWiseRmBkdWithAdvView>> getCatWiseRoomBkdWithAdv();

    }
}
