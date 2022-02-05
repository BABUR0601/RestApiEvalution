using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.Repository
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly hotelContext _db;

        public CustomerRepo(hotelContext db)
        {
            _db = db;
        }

        public async Task<int> AddCustomer(Customer rm)
        {
            if (_db != null)

            {
                await _db.Customer.AddAsync(rm);
                await _db.SaveChangesAsync();
                return rm.CustId;
            }
            return 0;
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var room = await _db.Customer.FirstOrDefaultAsync(x => x.CustId == id);
            if (room != null)
            {
                _db.Customer.Remove(room);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<List<Customer>> getAllCustomer()
        {
            return await _db.Customer.ToListAsync();
        }

        public async Task UpdCustomer(Customer rm)
        {
            _db.Entry(rm).State = EntityState.Modified;
            _db.Customer.Update(rm);
            await _db.SaveChangesAsync();
        }
    }
}
