using Cdr.ContactMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.Tests.UnitTests.Helpers
{
    public class SampleTestData
    {
        public static List<Contact> contactData=new List<Contact>
            {
                new Contact("Albert","Einstein","Kaiser Wilhelm Physical Institute"),
                new Contact("Isaac","Newton","Isaac Newton Ltd"),
                new Contact("Nicola","Tesla","Tesla Electric Co"),
                new Contact("Leonhard","Euler","Leonard Euler Ltd")

            };
    }
}
