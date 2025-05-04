using EF_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure services
            builder.Services.AddDbContext<StudentDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Define endpoints
            app.MapGet("/students", async (StudentDbContext db) =>
            {
                var students = await db.Students.ToListAsync();
                return Results.Ok(students);
            });

            app.MapPost("/students", async (Student student, StudentDbContext db) =>
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return Results.Created($"/students/{student.Id}", student);
            });

            app.MapPut("/students/{id}", async (int id, Student updatedStudent, StudentDbContext db) =>
            {
                var student = await db.Students.FindAsync(id);
                if (student is null) return Results.NotFound();

                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.EnrollmentDate = updatedStudent.EnrollmentDate;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/students/{id}", async (int id, StudentDbContext db) =>
            {
                var student = await db.Students.FindAsync(id);
                if (student is null) return Results.NotFound();

                db.Students.Remove(student);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.Run();
        }
    }
}