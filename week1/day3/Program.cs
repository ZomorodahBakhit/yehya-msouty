using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;
using System.Runtime.Intrinsics.Arm;

var db = new AppDbContext();


var student1 = new User { FirstName = "Yehya", LastName = "Msouty", EmailAddress = "yeay@gmail.com", PhoneNumber = "0921374231", Role = "Student" };
var student2 = new User { FirstName = "mouaz", LastName = "ahmad", EmailAddress = "mouaz@gmail.com", PhoneNumber = "0924374332", Role = "Student" };
var student3 = new User { FirstName = "motaz", LastName = "khoder", EmailAddress = "motaz@gmail.com", PhoneNumber = "0933374233", Role = "Student" };
var student4 = new User { FirstName = "ayman", LastName = "kaled", EmailAddress = "ayman@gmail.com", PhoneNumber = "0923344234", Role = "Student" };

var teacher1 = new User { FirstName = "Sami", LastName = "hijazy", EmailAddress = "sami@gmail.com", PhoneNumber = "0933374235", Role = "Teacher" };
var teacher2 = new User { FirstName = "Feryal", LastName = "hih", EmailAddress = "feryal@gmail.com", PhoneNumber = "0923312336", Role = "Teacher" };

var syllabus1 = new Syllabus { Description = "Syrian Syllabus" };
var syllabus2 = new Syllabus { Description = "Syrian Syllabus" };
var syllabus3 = new Syllabus { Description = "Syrian Syllabus" };
var syllabus4 = new Syllabus { Description = "Syrian Syllabus" };



//db.AddRange(student1, student2, student3, student4, teacher1, teacher2);
//db.AddRange(syllabus1, syllabus2, syllabus3, syllabus4);
//db.SaveChanges();
var course1 = new Course { CourseName = "Sql", TeacherId = teacher1.Id, Syllabus = syllabus1 };
var course2 = new Course { CourseName = "C#", TeacherId = teacher1.Id, Syllabus = syllabus2 };
var course3 = new Course { CourseName = "Entity Framework", TeacherId = teacher1.Id, Syllabus = syllabus3 };
var course4 = new Course { CourseName = "React", TeacherId = teacher1.Id, Syllabus = syllabus4 };

//db.AddRange(course1, course2, course3, course4);

//db.SaveChanges();

var Assignment1 = new Assignment { Course = course1, AssignmentTitle = "Sql Assignment",Description="addasasddas" ,Weight = 4, MaxGrade = 100, DueDate = DateTime.Parse("2026-04-04") };
//db.Add(Assignment1);

// db.SaveChanges();

var comments = new List<Comment>
{
    new Comment { AssignmentId = Assignment1.Id, UserId = student1.Id, CreatedDate = DateTime.Now, CommentContent = "Could you please clarify the deadline for this task?" },
    new Comment { AssignmentId = Assignment1.Id, UserId = teacher1.Id, CreatedDate = DateTime.Now.AddMinutes(5), CommentContent = "The deadline is fixed for next Saturday, no extensions." },
    new Comment { AssignmentId = Assignment1.Id, UserId = student2.Id, CreatedDate = DateTime.Now.AddHours(1), CommentContent = "I have submitted my solution. Please check it." },
    new Comment { AssignmentId =  Assignment1.Id, UserId = student3.Id, CreatedDate = DateTime.Now.AddHours(2), CommentContent = "This C# challenge was quite interesting!" },
    new Comment { AssignmentId =  Assignment1.Id, UserId = teacher1.Id, CreatedDate = DateTime.Now.AddHours(3), CommentContent = "Great effort everyone, proud of your progress." },
    new Comment { AssignmentId = Assignment1.Id, UserId = student4.Id, CreatedDate = DateTime.Now, CommentContent = "I am facing an issue with the database connection string." },
    new Comment { AssignmentId = Assignment1.Id, UserId = teacher2.Id, CreatedDate = DateTime.Now.AddMinutes(15), CommentContent = "Make sure you used 'EnsureCreated' before testing." },
    new Comment { AssignmentId =  Assignment1.Id, UserId = student1.Id, CreatedDate = DateTime.Now, CommentContent = "React hooks are a bit confusing at first." },
    new Comment { AssignmentId =  Assignment1.Id, UserId = student2.Id, CreatedDate = DateTime.Now.AddMinutes(10), CommentContent = "I agree, especially useEffect hook." },
    new Comment { AssignmentId =  Assignment1.Id, UserId = teacher1.Id, CreatedDate = DateTime.Now.AddHours(1), CommentContent = "Don't worry, we will review hooks thoroughly in tomorrow's session." }
};

//db.AddRange(comments);
//db.SaveChanges();
var stu1 = db.Users.Find(1);
var stu2 = db.Users.Find(2);
var stu3 = db.Users.Find(3);
var stu4 = db.Users.Find(4);

var assign1 = db.Assignment.Find(1);

var Grades= new List<Grade> {
         new Grade { AssignmentId = assign1.Id, Assignment = assign1 ,StudentId = stu1.Id, Student = stu1,StudentGrade = 100},
         new Grade { AssignmentId = assign1.Id, Assignment = assign1 ,StudentId = stu2.Id, Student = stu2,StudentGrade = 100},
         new Grade { AssignmentId = assign1.Id, Assignment = assign1 ,StudentId = stu3.Id, Student = stu3,StudentGrade = 100},
         new Grade { AssignmentId = assign1.Id, Assignment = assign1 ,StudentId = stu4.Id, Student = stu4,StudentGrade = 100},
    };

//db.AddRange(Grades);
//db.SaveChanges();

var coursesList = db.Courses.ToList();
foreach(var course in coursesList)
{
    Console.WriteLine($"Course: {course.CourseName}");
}

db.Users.Where(c => c.Role == "Student").ToList().ForEach(c => Console.WriteLine($"Student: {c.FirstName} {c.LastName}"));

db.Assignment.Where(a=> a.Course.CourseName == "Sql").ToList().ForEach(a => Console.WriteLine(a.AssignmentTitle));

//db.Comment.Where(c => c.Assignment.
// it didn't wokrs

db.Grades.Where(g => g.StudentId==1 ).ToList().ForEach(a => Console.WriteLine(a.StudentGrade));

db.Assignment.ToList().ForEach(a => { Console.Write($"{a.Course.CourseName}  ");
    db.Users.Where(u => u.Id == a.Course.TeacherId).ToList().ForEach(a => Console.WriteLine($"{a.FirstName} {a.LastName}"));
});


var courseList = db.Courses.ToList();
foreach( var course in courseList)
{
    var assignment_course = db.Assignment.Where(a => a.Course.Id == course.Id).ToList();
    var gcount = db.Grades.Where(g => g.Assignment.Course.Id == course.Id).ToList().Count();
    var gsum = 0;
    db.Grades.Where(g => g.Assignment.Course.Id == course.Id).ToList().ForEach(c =>
     {
         gsum +=c.StudentGrade ;
     } );
    if(gcount > 0)
    {
        var avg = gsum / gcount;
        Console.WriteLine($"Course: {course.CourseName}, Average Grade: {avg}");
    }

}

var studentToUpdate = db.Users.Find(1);

if (studentToUpdate != null)
{
    studentToUpdate.Role = "Teacher";
}

var comment = db.Comment.Find(1);

if (comment != null)
{
    db.Comment.Remove(comment);
}
