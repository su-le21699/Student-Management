using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class StudentManagement
{
    private List<Student> ListStudent = null;
    public StudentManagement()
    {
        ListStudent = new List<Student>();
    }
    public int GenerateID()
    {
        int max = 1;
        if (ListStudent != null && ListStudent.Count > 0)
        {
            max = ListStudent[0].ID;
            foreach (Student stu in ListStudent)
            {
                if (max < stu.ID)
                {
                    max = stu.ID;
                }
            }
            max++;
        }
        return max;
    }
    public void AverageScores(Student stu)
    {
        double AverageSubjects = (stu.Math + stu.Physical + stu.Chemical) / 3;
        stu.AverageSubjects = Math.Round(AverageSubjects, 2, MidpointRounding.AwayFromZero);
    }
    public void TypeRanking(Student stu)
    {
        if (stu.AverageSubjects >= 8)
        {
            stu.Type = "Excellent";
        }
        else if (stu.AverageSubjects < 8 && stu.AverageSubjects >= 6.5)
        {
            stu.Type = "Good";
        }
        else if (stu.AverageSubjects < 6.5 && stu.AverageSubjects >= 5)
        {
            stu.Type = "Not Good";
        }
        else if (stu.AverageSubjects < 5)
        {
            stu.Type = "Bad";
        }
    }
    public int TotalStudents()
    {
        int count = 0;
        if (ListStudent != null)
        {
            count = ListStudent.Count;
        }
        return count;
    }
    public void InputStudent()
    {
        Student stu = new Student();
        stu.ID = GenerateID();
        Console.WriteLine("Input student name: ");
        stu.Name = Convert.ToString(Console.ReadLine());

        Console.WriteLine("Input student sex: ");
        stu.Sex = Convert.ToString(Console.ReadLine());

        Console.WriteLine("Input student age: ");
        stu.Age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Input math score : ");
        stu.Math = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Input physical score : ");
        stu.Physical = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Input chemical score : ");
        stu.Chemical = Convert.ToDouble(Console.ReadLine());

        AverageScores(stu);
        TypeRanking(stu);

        ListStudent.Add(stu);

    }
    public Student FindByID(int ID)
    {
        Student searchResult = null;
        if (ListStudent != null && ListStudent.Count > 0)
        {
            foreach (Student stu in ListStudent)
            {
                if (stu.ID == ID)
                {
                    searchResult = stu;
                }
            }
        }
        return searchResult;
    }
    public void UpdateStudentByID(int ID)
    {
        Student stu = FindByID(ID);
        if (stu != null)
        {
            Console.WriteLine("Input student name: ");
            string name = Convert.ToString(Console.ReadLine());
            if (name != null && name.Length > 0)
            {
                stu.Name = name;
            }

            Console.WriteLine("Input student sex: ");
            string sex = Convert.ToString(Console.ReadLine());
            if (sex != null && sex.Length > 0)
            {
                stu.Sex = sex;
            }

            Console.WriteLine("Input student age: ");
            string age = Convert.ToString(Console.ReadLine());
            if (age != null && age.Length > 0)
            {
                stu.Age = Convert.ToInt32(age);
            }

            Console.WriteLine("Input student math score: ");
            string math = Convert.ToString(Console.ReadLine());
            if (math != null && math.Length > 0)
            {
                stu.Math = Convert.ToDouble(math);
            }

            Console.WriteLine("Input student physical score: ");
            string physic = Convert.ToString(Console.ReadLine());
            if (physic != null && physic.Length > 0)
            {
                stu.Physical = Convert.ToDouble(physic);
            }

            Console.WriteLine("Input student chemical score: ");
            string chemical = Convert.ToString(Console.ReadLine());
            if (chemical != null && chemical.Length > 0)
            {
                stu.Chemical = Convert.ToDouble(chemical);
            }

            AverageScores(stu);
            TypeRanking(stu);
        }
        else
        {
            Console.WriteLine("The student has ID = {0} no exist.", ID);
        }
    }
    public bool DeleteByID(int ID)
    {
        bool IsDeleted = false;
        Student stu = FindByID(ID);
        if (stu != null)
        {
            IsDeleted = ListStudent.Remove(stu);
        }
        return IsDeleted;
    }
    public List<Student> FindByName(string name)
    {
        List<Student> searchResult = new List<Student>();
        if (ListStudent != null && ListStudent.Count > 0)
        {
            foreach (Student stu in ListStudent)
            {
                if (stu.Name.ToUpper().Contains(name.ToUpper()))
                {
                    searchResult.Add(stu);
                }
            }
        }
        return searchResult;
    }

    public void SortByID()
    {
        ListStudent.Sort(delegate (Student stu1, Student stu2)
        {
            return stu1.ID.CompareTo(stu2.ID);
        });
    }
    public void SortByName()
    {
        ListStudent.Sort(delegate (Student stu1, Student stu2)
        {
            return stu1.Name.CompareTo(stu2.Name);
        });
    }
    public void SortByAverageScore()
    {
        ListStudent.Sort(delegate (Student stu1, Student stu2)
        {
            return stu1.AverageSubjects.CompareTo(stu2.AverageSubjects);
        });
    }
    public void ShowStudent(List<Student> listStudent)
    {
        // show column title
        Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
              "ID", "Name", "Sex", "Age", "Math", "Physical", "Chemical", "Average Subjects", "Type");
        // show list if students
        if (listStudent != null && listStudent.Count > 0)
        {
            foreach (Student stu in listStudent)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                                  stu.ID, stu.Name, stu.Sex, stu.Age, stu.Math, stu.Physical,
                                  stu.Chemical, stu.AverageSubjects, stu.Type);
            }
        }
        Console.WriteLine();
    }
    // List of students at present
    public List<Student> getListStudent()
    {
        return ListStudent;
    }
}