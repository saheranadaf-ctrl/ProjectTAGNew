// IStudentService.cs in StudentAPI project
using StudentAPI.DataAccess;
public interface IStudentService
{
    Task<List<School>> CreateStudent();
    Task<List<School>> UpdateStudent();
    Task<List<School>> DeleteStudent();
    Task<List<School>> GetAll();
    Task<School> GetStudentById(string studentId);
    // Define other methods and properties related to student services
}
