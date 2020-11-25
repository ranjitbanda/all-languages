using DataAccess;
using DataAccess.Fakes;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.Fakes;

namespace ServicesTests
{
    [TestClass]
    public class StudentRegistrationServiceTests
    {
        [TestMethod]
        public void RegisterNewStudent_SavesTheStudent_STUB_TO_TEST_METHOD()
        {
            bool wasSaveCalled = false; 
            //Stub for student repository interface 
            // fake implementation for Save method in this interface
            IStudentRepository stubStudentRepository = new StubIStudentRepository
            {
                SaveStudent = (x) => { wasSaveCalled = true; }
            };

            StudentRegistrationService studentRegistrationService = 
                    new StudentRegistrationService(stubStudentRepository);

            Student student = new Student();
            //ACT
            studentRegistrationService.RegisterNewStudent(student);
            //ASSERT
            Assert.IsTrue(wasSaveCalled);
        }

        [TestMethod]
        public void RegisterNewStudent_IsStudentSavedSet_STUB_TO_TEST_PROPERTY()
        {
            bool wasIsStudentSavedPropertySet = false;
            //Stub for student repository interface 
            //(As there is no interface for this so we are directly stubbing the class itself)
            // NOTE - We can stub for StudentRepository class also but is not a good practice
            IStudentRepository stubStudentRepository = new StubIStudentRepository()
            {
                IsStudentSavedSetBoolean = (value) => { wasIsStudentSavedPropertySet = true; }
            };
            
            StudentRegistrationService studentRegistrationService =
                    new StudentRegistrationService(stubStudentRepository);

            Student student = new Student();
            //ACT
            studentRegistrationService.RegisterNewStudent(student);
            //ASSERT
            Assert.IsTrue(wasIsStudentSavedPropertySet);
        }
    }
}
