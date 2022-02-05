using RoomManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public interface ICustomerRepo
    {

        Task<List<Customer>> getAllCustomer();
        Task<int> AddCustomer(Customer rm);
        Task UpdCustomer(Customer rm);
        Task<int> DeleteCustomer(int id);

    }
}
