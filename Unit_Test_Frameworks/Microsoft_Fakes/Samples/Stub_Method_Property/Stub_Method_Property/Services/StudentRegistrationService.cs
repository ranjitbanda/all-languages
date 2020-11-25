using DataAccess;
using Domain;

namespace Services
{
    public class StudentRegistrationService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentRegistrationService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void RegisterNewStudent(Student student)
        {
           _studentRepository.Save(student);
        }
    }
}