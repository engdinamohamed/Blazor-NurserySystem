using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IContactService
    {
        Task<Contact> GetContact();
        Task<bool> UpdateContact(Contact contact);
    }
}
