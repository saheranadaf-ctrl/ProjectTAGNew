using Microsoft.EntityFrameworkCore;
using StudentAPI.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class StudentService : IStudentService
{
    private readonly StudentDataContext _dbContext;

    public StudentService(StudentDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<School> CreateStudent(School student)
    {
        _dbContext.Schools.Add(student);
        await _dbContext.SaveChangesAsync();
        return student;
    }

    public async Task<School?> UpdateStudent(string studentId, School updatedStudent)
    {
        var existingStudent = await _dbContext.Schools.FirstOrDefaultAsync(s => s.StudentId == studentId);

        if (existingStudent != null)
        {
            // Update existingStudent properties with non-null values from updatedStudent
            // For example:
            // existingStudent.Name = updatedStudent.Name ?? existingStudent.Name;
            // ...

            await _dbContext.SaveChangesAsync();
        }

        return existingStudent;
    }

    public async Task<School?> DeleteStudent(string studentId)
    {
        var existingStudent = await _dbContext.Schools.FirstOrDefaultAsync(s => s.StudentId == studentId);

        if (existingStudent != null)
        {
            _dbContext.Schools.Remove(existingStudent);
            await _dbContext.SaveChangesAsync();
        }

        return existingStudent;
    }

    public async Task<List<School>> GetAll()
    {
        return await _dbContext.Schools.ToListAsync();
    }

    public async Task<School?> GetStudentById(string studentId)
    {
        return await _dbContext.Schools.FirstOrDefaultAsync(s => s.StudentId == studentId);
    }
}
