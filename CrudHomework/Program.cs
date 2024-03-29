﻿// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Diagnostics;
using System.Xml.Linq;

CategoryManager categoryManager = new CategoryManager(new CategoryDal());
Category category = new Category() { Id = 1, Name = "C#" };
Category category2 = new Category() { Id = 2, Name = "Python" };
categoryManager.Add(category);
categoryManager.Add(category2);

Instructor ınstructor = new Instructor() { Id = 1, Name = "Engin", LastName = "Demiroğ" };
Instructor ınstructor2 = new Instructor() { Id = 2, Name = "Halit Enes", LastName = "Kalaycı" };
InstructorManager ınstructorManager = new InstructorManager(new InstructorDal());
ınstructorManager.Add(ınstructor);
ınstructorManager.Add(ınstructor2);

CourseManager courseManager = new CourseManager(new CourseDal());

courseManager.Add(new Course { Id = 1, Name = "C# Kampı", Description = "2024 Yazılım Geliştirici Yetiştirme Kampı (C#)", InstructorId = 1, Instructor = ınstructor, ImageUrl = "1.jpg", Price = 1, CategoryId = 1, Category = category });
courseManager.Add(new Course() { Id = 2, Name = "Python Kampı", Description = "2023 Yazılım Geliştirici Yetiştirme Kampı - Python & Selenium", InstructorId = 2, Instructor = ınstructor2, ImageUrl = "2.jpg", Price = 10, CategoryId = 2, Category = category2 });

var courses = courseManager.GetAll();
Console.WriteLine("Kurs listesi");
Console.WriteLine();
foreach (var course in courses)
{
    Console.WriteLine("Course Name: " + course.Name);
    Console.WriteLine("Course Description: " + course.Description);
    Console.WriteLine("Course Price: " + course.Price);
    Console.WriteLine("Course Category: " + course.Category.Name);
    Console.WriteLine("Course Instructor: " + course.Instructor.Name);
    Console.WriteLine();
}

Console.WriteLine("*******");
Console.WriteLine();

var ınstructors = ınstructorManager.GetAll();

Console.WriteLine("Yeni eğitmen eklenmeden önceki eğitmen listesi");
Console.WriteLine();
PrintAllValues(ınstructors);

Console.WriteLine("*******");
Console.WriteLine();

Instructor ınstructor3 = new Instructor() { Id = 3, Name = "Mehmet", LastName = "Acar" };
ınstructorManager.Add(ınstructor3);
var ınstructors2 = ınstructorManager.GetAll();

Console.WriteLine("Yeni eğitmen eklendikten sonraki eğitmen listesi");
Console.WriteLine();
PrintAllValues(ınstructors2);

Console.WriteLine("*******");
Console.WriteLine();

ınstructor3.Name = "Murat";
ınstructor3.LastName = "Yılmaz";
ınstructorManager.Update(ınstructor3);
var ınstructors3 = ınstructorManager.GetAll();
Console.WriteLine();
Console.WriteLine("Eğitmen güncellemesinden sonraki eğitmen listesi");
Console.WriteLine();
PrintAllValues(ınstructors3);

Console.WriteLine("*******");
Console.WriteLine();

ınstructorManager.Delete(ınstructor3);
var ınstructors4 = ınstructorManager.GetAll();
Console.WriteLine();
Console.WriteLine("Eğitmen silinmesinden sonraki eğitmen listesi");
Console.WriteLine();
PrintAllValues(ınstructors4);

void PrintAllValues(List<Instructor> ınstructors)
{
    foreach (var instructor in ınstructors)
    {
        Console.WriteLine("Instructor Name: " + instructor.Name);
        Console.WriteLine("Instructor Last Name: " + instructor.LastName);
        Console.WriteLine();
    }
}