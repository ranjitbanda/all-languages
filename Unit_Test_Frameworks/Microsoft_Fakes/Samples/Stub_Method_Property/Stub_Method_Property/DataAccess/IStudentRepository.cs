using Domain;

namespace DataAccess
{
    public interface IStudentRepository
    {
        Student FindById(int id);
        void Save(Student student);
    }
}