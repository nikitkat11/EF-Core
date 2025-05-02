using EF-Core.Models;

using var context = new StudentDbContext();

Console.WriteLine("List of Students:");
foreach (var student in context.Students)
{
    Console.WriteLine($"{student.Id}: {student.Name} - {student.Email} ({student.EnrollmentDate.ToShortDateString()})");
}