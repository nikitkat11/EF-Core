using EF_Core.Models;

using var context = new StudentDbContext();

var students = context.Students.ToList();

foreach (var student in students)
{
    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Email: {student.Email}, Enrolled: {student.EnrollmentDate}");
}