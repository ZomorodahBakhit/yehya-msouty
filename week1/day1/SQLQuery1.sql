CREATE TABLE Users (
UsersId int Primary key ,
FirstName varchar(64) not null ,
LastName varchar(64) not null ,
EmailAddress varchar(128) not null ,
PhoneNubmer varchar(16) not null ,
Role varchar(32) not null 
)
CREATE TABLE Syllabus (
    SyllabusId INT PRIMARY KEY,
    Description text 
);

CREATE TABLE Course (
CourseId int Primary key ,
CourseName varchar(100) not null ,
TeacherId int ,
StartDate DateTime  not null ,
EndDate DateTime not null , 
SyllabusId  int foreign key REFERENCES  Syllabus(SyllabusId)
);

CREATE TABLE Assignment (
   AssignmentId int  primary key,
   CourseId int not null foreign key references Course (CourseId) ,
   AssignmentTitle varchar(128) not null,
   Description text not null,
   Weight float not null ,
   MaxGrade int not null,
   DueDate date not null
);

CREATE TABLE Comments (
    CommentId INT PRIMARY KEY ,
    AssignmentId INT NOT NULL foreign key references Assignment(AssignmentID),
    CreatedByUserId INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    CommentContent TEXT 
);

CREATE TABLE Grades (
    GradeId INT PRIMARY KEY,
    AssignmentId INT NOT NULL foreign key references Assignment(AssignmentID),
    StudentId INT NOT NULL foreign key references Users(UsersId),
    Grade INT 
);

ALTER TABLE Users
ADD CONSTRAINT MakeItQuenie unique(EmailAddress);
 
ALTER TABLE Course
Alter COLUMN TeacherId int ;


insert into users 
values 
(1,'yehya','msouty','yehya@gmail.com',0932332323,'student'),
(2,'motaz','masri','motaz@gmail.com',0933432398,'student'),
(3,'zuhair','homsi','zuhair@gmail.com',0932456238,'student'),
(4,'ayman','durra','ayman@gmail.com',0932356323,'student');

insert into users 
values 
(91,'Sami','Hijazi','sami@gmail.com',0932332323,'Teacher'),
(92,'feryal','feryal','feryal@gmail.com',0933432398,'Teacher');


insert into Course (CourseId,CourseName,StartDate,EndDate)
values 
(1,'C#','2026-2-2','2026-10-2'),
(2,'Entity Framework','2026-2-2','2026-10-2'),
(3,'Web Api','2026-2-2','2026-10-2'),
(4,'React Courses','2026-2-2','2026-10-2');

INSERT INTO Assignment (AssignmentID, CourseId, AssignmentTitle, Description, Weight, MaxGrade, DueDate) VALUES
(1, 1, 'Database Design Quiz', 'Design an ER diagram for a library system.', 10.0, 100, '2026-05-15'), 
(2, 1, 'SQL Joins Practice', 'Complete the practice sheet on inner and outer joins.', 15.0, 100, '2026-06-10'), 
(3, 1, 'Midterm Project', 'Build a fully normalized relational database.', 25.0, 100, '2026-07-05'), 
(4, 1, 'Indexing & Performance', 'Analyze query execution plans.', 10.0, 100, '2026-07-20'), 
(5, 1, 'Final Submission', 'Submit the final project repository link.', 40.0, 100, '2026-08-10'), 
(6, 2, 'HTML/CSS Basics', 'Create a responsive landing page.', 10.0, 100, '2026-05-20'), 
(7, 2, 'JavaScript Fundamentals', 'Implement form validation using JS.', 15.0, 100, '2026-06-12'),
(8, 2, 'React Component Task', 'Build a dynamic todo app with components.', 20.0, 100, '2026-07-01'),
(9, 2, 'API Integration', 'Fetch and display data from a public API.', 15.0, 100, '2026-07-25'),
(10, 2, 'Full-Stack Graduation Project', 'Deploy your complete web application.', 40.0, 100, '2026-08-15'),
(11, 3, 'Python Syntax Basics', 'Variables, loops, and conditions tasks.', 10.0, 100, '2026-05-18'), 
(12, 3, 'Data Structures Quiz', 'Implement Lists and Dictionaries.', 15.0, 100, '2026-06-05'), 
(13, 3, 'File Handling Lab', 'Read and write structured data from CSV files.', 15.0, 100, '2026-07-02'), 
(14, 3, 'OOP Project', 'Create a banking system using classes and inheritance.', 30.0, 100, '2026-07-22'), 
(15, 3, 'Data Analysis Assignment', 'Use Pandas to clean a given dataset.', 30.0, 100, '2026-08-08'), 
(16, 4, 'Networking Models Overview', 'Compare OSI model vs TCP/IP layers.', 10.0, 100, '2026-05-22'), 
(17, 4, 'IP Subnetting Task', 'Divide a network into required subnets.', 20.0, 100, '2026-06-15'), 
(18, 4, 'Routing Protocols Lab', 'Configure static and dynamic routing.', 20.0, 100, '2026-07-08'), 
(19, 4, 'Network Security Essay', 'Research common cyber attacks and firewalls.', 15.0, 100, '2026-07-28'),
(20, 4, 'Final Lab Exam', 'Build and troubleshoot a full topology in Packet Tracer.', 35.0, 100, '2026-08-18'); 




INSERT INTO Comments (CommentId, AssignmentId, CreatedByUserId, CreatedDate, CommentContent)
VALUES 
(1,  3, 10, GETDATE(), 'First comment on assignment 3'),
(2,  1, 15, GETDATE(), 'This needs more review'),
(3,  5, 22, GETDATE(), 'Great work on this task'),
(4,  2, 12, GETDATE(), 'Please check the requirements again'),
(5,  4, 19, GETDATE(), 'Finished my part of the assignment'),
(6,  1, 33, GETDATE(), 'Can we get an extension?'),
(7,  3, 45, GETDATE(), 'Adding a random note here'),
(8,  5, 11, GETDATE(), 'The code looks clean and neat'),
(9,  2, 27, GETDATE(), 'I have a question about this step'),
(10, 4, 50, GETDATE(), 'Final submission comment');


-- Ai
INSERT INTO Grades (GradeId, AssignmentId, StudentId, Grade)
VALUES
(1,1,1,20),
(2,1,2,40),
(3,1,3,50),
(4,1,4,100),

(5,2,1,50),
(6,2,2,60),
(7,2,3,80),
(8,2,4,80),

(9,3,1,40),
(10,3,2,20),
(11,3,3,20),
(12,3,4,10),

(13,4,1,40),
(14,4,2,10),
(15,4,3,20),
(16,4,4,20);
INSERT INTO Syllabus (SyllabusId, Description)
SELECT 
    CourseId, 
    'Syllabus description for ' + CourseName
FROM Course;

--Ai


select * from Course;


select AssignmentTitle from Assignment
where CourseId=1;


select FirstName , LastName from Users
where Role = 'inter';



update Users
set Role='inter'
where Role= 'student';



Delete from Comments
where  CommentId= 1; 




select U.FirstName ,U.LastName,G. Grade, C.courseName from Grades G
join Assignment A
on  G.AssignmentId= A.AssignmentID
join Course C
on C.CourseId = A.CourseId 
join Users U
on U.UsersId = G. StudentId
where U.Role='inter' and C.CourseId= 1;




select  Avg(G.Grade)  AS AvgGrade from Grades G
join Assignment A
on A.AssignmentId =G.AssignmentId
join Course C
on C.CourseId =A.CourseId
group by C.CourseId;




select C.CourseName ,  S.Description from Course C
left join Syllabus S
on C.SyllabusId =S.SyllabusId;



select C.CommentId ,C.CommentContent ,co.CourseId from Comments C
join Assignment A
on C .AssignmentId = A.AssignmentID
join Course Co
on Co.CourseId=A.CourseId
where Co.CourseId =1;





CREATE PROCEDURE AddNewStudent 
@UsersId int ,
@FirstName varchar(64) ,
@LastName varchar(64) ,
@EmailAddress varchar(128) ,
@PhoneNubmer varchar(16) 
AS 
BEGIN   
    INSERT INTO Users (UsersId ,FirstName  ,LastName ,EmailAddress  ,PhoneNubmer,Role)
    VALUES (@UsersId ,@FirstName  ,@LastName ,@EmailAddress ,@PhoneNubmer,'student');
END

EXEC AddNewStudent 12 , '21','12','12','12';





 Create PROCEDURE AddNewAssignment
    @AssignmentID INT,
    @CourseId INT,
    @AssignmentTitle VARCHAR(128),
    @Descriprtion TEXT,
    @Weight FLOAT,
    @MaxGrade INT,
    @DueDate DATE
AS
BEGIN 
    DECLARE @var INT;
    SELECT @var = SUM(Weight) FROM Assignment WHERE CourseId = @CourseId;
     PRINT @var ;
    PRInt @Weight ;
    IF  (@Weight + ISNULL(@var, 0)) <= 100 begin PRINT '--- بدأت العملية لـ CourseId:'
    BEGIN 
        INSERT INTO Assignment (AssignmentID, CourseId, AssignmentTitle, Description, Weight, MaxGrade, DueDate)
        VALUES (@AssignmentID, @CourseId, @AssignmentTitle, @Descriprtion, @Weight, @MaxGrade, @DueDate);
    END end
END;
GO


CREATE FUNCTION getGrade(
    @StudentId INT,
    @CourseId INT
)
RETURNS CHAR(1)
AS
BEGIN
    DECLARE @var INT;
    SELECT @var = AVG(G.Grade) FROM Grades G
    JOIN Assignment A ON G.AssignmentId = A.AssignmentID
    WHERE G.StudentId = @StudentId AND A.CourseId = @CourseId;

    RETURN
    CASE 
        WHEN @var >= 90 THEN 'A'
        WHEN @var >= 80 THEN 'B'
        WHEN @var >= 70 THEN 'C'
        WHEN @var >= 60 THEN 'D'
        ELSE 'F'
    END;
END;
GO


create function GPA(@StudentId int,@CoursesId int)
RETURNS INT
AS
BEGIN
    DECLARE @var float;
    select @var =  SUM(G.Grade * A.Weight) / SUM(A.Weight) from Assignment A join Grades G
    on A.AssignmentId= G.AssignmentId
    where G.StudentId=@StudentId and A.CourseId=@CoursesId;
    RETURN @var
END;
GO

select * from Users;
select * from Course;
select * from Syllabus;
select * from Assignment;
select * from Comments;
select * from  Grades;

SELECT dbo.getGrade(1,1);


 EXEC AddNewAssignment 2, 2, 'Database Design Quiz', 'Design an ER diagram for a library system.', 10.0, 100, '2026-05-15';
