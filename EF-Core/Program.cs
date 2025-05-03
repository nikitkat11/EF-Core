using EF_Core.Models;
using Microsoft.EntityFrameworkCore;

using var context = new StudentDbContext();


var newStudent = new Student
{
    Name = "Charlie",
    Email = "charlie@example.com",
    EnrollmentDate = new DateOnly(2023, 9, 1) 
};

context.Students.Add(newStudent);
context.SaveChanges();
Console.WriteLine("New student added!");

var students = context.Students.ToList();

Console.WriteLine("List of students:");
foreach (var student in students)
{
    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Email: {student.Email}, Enrolled: {student.EnrollmentDate}");
}
