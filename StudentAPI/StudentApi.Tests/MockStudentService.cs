using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.DataAccess;
using StudentAPI.StudentService;
 // Ensure you have the correct namespace for your Student model class

public class MockStudentService : IStudentService
{
    private readonly List<School> _students;

    public MockStudentService(List<School> students)
    {
        _students = students;
    }

    public Task<List<School>> GetAll()
    {
        return Task.FromResult(_students);
    }

    public Task<School?> GetStudentById(string studentId)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        return Task.FromResult(student);
    }

    public Task<School> CreateStudent(School student)
    {
        // Implement create logic for testing purposes (if needed)
        // For example, add the student to the _students list
        // _students.Add(student);
        // Return the created student
        return Task.FromResult(student);
    }

    public Task<School?> UpdateStudent(string studentId, School updatedStudent)
    {
        // Implement update logic for testing purposes (if needed)
        // For example, find the student in the _students list and update its properties
        // Return the updated student
        return Task.FromResult<School?>(updatedStudent);
    }
    
    public Task<School?> DeleteStudent(string studentId)
    {
        // Implement delete logic for testing purposes (if needed)
        // For example, remove the student from the _students list
        // Return the deleted student
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        if (student != null)
        {
            _students.Remove(student);
        }
        return Task.FromResult(student);
    }
}
