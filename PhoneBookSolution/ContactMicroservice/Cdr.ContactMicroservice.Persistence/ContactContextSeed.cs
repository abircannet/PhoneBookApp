using Cdr.ContactMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Persistence
{
    public class ContactContextSeed
    {
        public static async Task SeedAsync(ContactDbContext context, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
                context.Database.Migrate();
                if (!await context.Contacts.AnyAsync())
                {
                    await context.Contacts.AddRangeAsync( GetPreConfiguredContactData());
                    await context.SaveChangesAsync();
                }
                

            }
            catch (Exception)
            {

                if (retryForAvailability >= 10) throw;
                retryForAvailability++;

                await SeedAsync(context, retryForAvailability);
                throw;
            }
        }

        private static IEnumerable<Contact> GetPreConfiguredContactDetailData(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                contact.AddDetail(new ContactDetail(ContactDetailType.Phone, "1-459-852-4565"));
                contact.AddDetail(new ContactDetail(ContactDetailType.Phone, "1-459-852-4566"));
                contact.AddDetail(new ContactDetail(ContactDetailType.Email, $"{contact.Name}@outlook.com"));
                contact.AddDetail(new ContactDetail(ContactDetailType.Location, "Ulm"));
                contact.AddDetail(new ContactDetail(ContactDetailType.Location, "Basel"));
                contact.AddDetail(new ContactDetail(ContactDetailType.Location, "Smiljan"));
            }

            return contacts;
        }

        private static IEnumerable<Contact> GetPreConfiguredContactData()
        {
            var contacts = new List<Contact>
            {
                new Contact("Albert","Einstein","Kaiser Wilhelm Physical Institute"),
                new Contact("Isaac","Newton","Isaac Newton Ltd"),
                new Contact("Nicola","Tesla","Tesla Electric Co"),
                new Contact("Leonhard","Euler","Leonard Euler Ltd")

            };


            return GetPreConfiguredContactDetailData(contacts);
        }
    }
}
