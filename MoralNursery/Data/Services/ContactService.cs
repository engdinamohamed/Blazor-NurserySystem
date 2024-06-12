using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class ContactService : IContactService
    {
      
        private readonly NurseryDbContext _nurseryDbContext;
        public ContactService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public async Task<Contact> GetContact()
        {
            return await _nurseryDbContext.Contacts.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            _nurseryDbContext.Contacts.Update(contact);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }
    }
}
