using System;
using System.Collections.Generic;
using System.Linq;
using MyCompanyName.AbpZeroTemplate.Constants;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.PhoneBook;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialPeopleAndPhoneCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialPeopleAndPhoneCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var quangvt = _context.Persons.FirstOrDefault(p => p.EmailAddress == "quangvt@hotmail.com");
            if (quangvt == null)
            {
                _context.Persons.Add(
                    new PhoneBook.Person
                    {
                        Name = "Quang",
                        Surname = "Vu",
                        EmailAddress = "quangvt@hotmail.com",
                        Phones = new List<Phone>
                                {
                                    new Phone {Type = PhoneType.Home, Number = "1112242"},
                                    new Phone {Type = PhoneType.Mobile, Number = "2223342"}
                                }
                    });
            }

            var sonvt = _context.Persons.FirstOrDefault(p => p.EmailAddress == "sonvt@hotmail.com");
            if (sonvt == null)
            {
                _context.Persons.Add(
                    new PhoneBook.Person
                    {
                        Name = "Son",
                        Surname = "Vu",
                        EmailAddress = "sonvt@hotmail.com",
                        Phones = new List<Phone>
                                {
                                    new Phone {Type = PhoneType.Home, Number = "8889977"}
                                }
                    });
            }
        }
    }
}
