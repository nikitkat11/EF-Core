using System;
using System.Collections.Generic;

namespace EF_Core.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateOnly? EnrollmentDate { get; set; }
}
