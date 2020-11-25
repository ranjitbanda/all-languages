using Domain;

namespace DataAccess
{
    public interface IStudentRepository
    {
        public bool IsStudentSaved { get; set; }
        Student FindById(int id);
        void Save(Student student);
    }
}