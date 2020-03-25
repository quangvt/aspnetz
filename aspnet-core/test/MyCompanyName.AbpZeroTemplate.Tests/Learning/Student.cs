using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using MyCompanyName.AbpZeroTemplate.Learning;
using MyCompanyName.AbpZeroTemplate.Learning.Dto;
using Shouldly;
using Xunit;

namespace MyCompanyName.AbpZeroTemplate.Tests.Learning
{
    public class StudentAppService_Tests : AppTestBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentAppService_Tests()
        {
            _studentAppService = Resolve<IStudentAppService>();
        }

        [Fact]
        public void Should_Get_All_Student_Without_Any_Filter()
        {
            //Act
            var students = _studentAppService.GetStudent(new GetStudentInput());

            //Assert
            students.Items.Count.ShouldBe(2);
        }

        [Fact]
        public void Should_Get_Student_With_Filter()
        {
            //Act
            var students = _studentAppService.GetStudent(
                new GetStudentInput
                {
                    Filter = "Douglas"
                });

            //Assert
            students.Items.Count.ShouldBe(1);
            students.Items[0].Name.ShouldBe("Douglas");
            students.Items[0].Surname.ShouldBe("Adams");
        }

        [Fact]
        public async Task Should_Create_Student_With_Valid_Arguments()
        {
            //Act
            await _studentAppService.CreateStudent(
                new CreateStudentInput
                {
                    Name = "John",
                    Surname = "Nash",
                    EmailAddress = "john.nash@abeautifulmind.com"
                });

            //Assert
            UsingDbContext(
                context =>
                {
                    var john = context.Students.FirstOrDefault(p => p.EmailAddress == "john.nash@abeautifulmind.com");
                    john.ShouldNotBe(null);
                    john.Name.ShouldBe("John");
                });
        }

        [Fact]
        public async Task Should_Not_Create_Student_With_Invalid_Arguments()
        {
            //Act and Assert
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _studentAppService.CreateStudent(
                        new CreateStudentInput
                        {
                            Name = "John"
                        });
                });
        }
    }
}
