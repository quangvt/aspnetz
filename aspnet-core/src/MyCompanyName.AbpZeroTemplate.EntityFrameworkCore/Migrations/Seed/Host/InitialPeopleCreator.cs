using System;
using System.Linq;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialPeopleCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialPeopleCreator(AbpZeroTemplateDbContext context)
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
                        EmailAddress = "quangvt@hotmail.com"
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
                        EmailAddress = "sonvt@hotmail.com"
                    });
            }
        }
    }
}
