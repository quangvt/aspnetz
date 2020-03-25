using System.Linq;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Learning;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialStudentCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialStudentCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Students.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.Students.Add(
                    new Student
                    {
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com",
                        TenantId = 1
                    });
            }

            var asimov = _context.Students.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Students.Add(
                    new Student
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org",
                        TenantId = 1
                    });
            }
        }
    }
}
