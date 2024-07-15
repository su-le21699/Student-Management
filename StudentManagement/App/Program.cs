using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        StudentManagement studentManagement = new StudentManagement();

        while (true)
        {
            Console.WriteLine("\nStudent Management C#");
            Console.WriteLine("*************************MENU**************************");
            Console.WriteLine("**  1. Add new student.                               **");
            Console.WriteLine("**  2. Update student infomation by ID.          **");
            Console.WriteLine("**  3. Delete student by ID.                         **");
            Console.WriteLine("**  4. Find student by name.                  **");
            Console.WriteLine("**  5. Sort student by Average Score (GPA). **");
            Console.WriteLine("**  6. Sort student by name.                   **");
            Console.WriteLine("**  7. Sort student by ID.                    **");
            Console.WriteLine("**  8. Show student list.                 **");
            Console.WriteLine("**  0. Exit                                         **");
            Console.WriteLine("*******************************************************");
            Console.Write("Enter option: ");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    Console.WriteLine("\n1. Add student.");
                    studentManagement.InputStudent();
                    Console.WriteLine("\nAdd student successfully!");
                    break;
                case 2:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        int ID;
                        Console.WriteLine("\n2. Update student infomation. ");
                        Console.Write("\nInput ID: ");
                        ID = Convert.ToInt32(Console.ReadLine());
                        studentManagement.UpdateStudentByID(ID);
                        Console.WriteLine("\nUpdate student successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 3:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        int ID;
                        Console.WriteLine("\n3. Delete student.");
                        Console.Write("\nInput ID: ");
                        ID = Convert.ToInt32(Console.ReadLine());
                        if (studentManagement.DeleteByID(ID))
                        {
                            Console.WriteLine("\nStudent has an ID = {0} is deleted.", ID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 4:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        Console.WriteLine("\n4. Find student by name.");
                        Console.Write("\nEnter the name: ");
                        string name = Convert.ToString(Console.ReadLine());
                        List<Student> searchResult = studentManagement.FindByName(name);
                        studentManagement.ShowStudent(searchResult);
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 5:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        Console.WriteLine("\n5. Sort student by Average Score (GPA).");
                        studentManagement.SortByAverageScore();
                        studentManagement.ShowStudent(studentManagement.getListStudent());
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 6:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        Console.WriteLine("\n6. Sort student by name.");
                        studentManagement.SortByName();
                        studentManagement.ShowStudent(studentManagement.getListStudent());
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 7:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        Console.WriteLine("\n6. Sort student by ID.");
                        studentManagement.SortByID();
                        studentManagement.ShowStudent(studentManagement.getListStudent());
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 8:
                    if (studentManagement.TotalStudents() > 0)
                    {
                        Console.WriteLine("\n7. Show student list.");
                        studentManagement.ShowStudent(studentManagement.getListStudent());
                    }
                    else
                    {
                        Console.WriteLine("\nList is empty!");
                    }
                    break;
                case 0:
                    Console.WriteLine("\nExisting the program...");
                    return;
                default:
                    Console.WriteLine("\nThis function is not available!");
                    Console.WriteLine("\nChoose options in the menu!");
                    break;
            }
        }
    }
}
