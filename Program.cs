using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// Рыбко Элоиза БСБО-15-21 
// 3 лабораторная
// 1 вариант


enum Education { Bachelor, Specialist, SecondEducation }
namespace EloiseLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            StudentCollection studentCollection = new StudentCollection(); //Создать объект типа StudentCollection. Добавить в коллекцию несколько различных элементов типа Student и вывести объект StudentCollection.
            studentCollection.AddDefaults();
            //var A = new Person("Stupid", "Liza", new DateTime(1987, 02, 11)); // два объекта типа персон
            //var B = new Person("Stupid", "Liza", new DateTime(1987, 02, 11));
            
            Console.WriteLine("Students list:\n");
            Console.WriteLine(studentCollection.ToShortString());
            //Console.WriteLine("By links: ");
            //Console.WriteLine(Object.ReferenceEquals(B, A));
            //Console.WriteLine("By values: ");
            //Console.WriteLine(A == B);
            Console.WriteLine("============================================================================================");
            Console.ReadKey();

            //2
            Console.WriteLine("Sort:"); //Для созданного объекта StudentCollection вызвать методы, выполняющие сортировку списка List<Student> по разным критериям, и после каждой сортировки вывести данные объекта. Выполнить сортировку

            //по фамилии студента;

            //по дате рождения;

            //по среднему баллу.

            Console.WriteLine("============================================================================================");
            studentCollection.SortSurname();
            Console.WriteLine("Surname:\n");
            Console.WriteLine(studentCollection.ToString());
            //Console.WriteLine("Hash: \n 1:\n {0}  \n 2:\n {1}", A.GetHashCode(), B.GetHashCode());
            Console.WriteLine("============================================================================================");
            Console.WriteLine(" \n");
            Console.ReadKey();


            studentCollection.SortDate();
            Console.WriteLine("Date of Birthsday:\n");
            Console.WriteLine(studentCollection.ToString());
            //Student student = new(new Person("Eloise", "Rybko", new DateTime(2003, 12, 25)), Education.Specialist, 15);// объект типа студент и сделать список экзамено и зачетов и вывести значение типа персон для студент
            //student.AddExams(new Exam("Math", 3, new DateTime(2022, 11, 29)));
            //student.AddTests(new Test("Hist", true));
            //student.AddExams(new Exam("Alg", 5, new DateTime(2022, 09, 11)));
            //student.AddTests(new Test("Deut", true));
            //student.AddExams(new Exam("Sety", 4, new DateTime(2022, 07, 05)));
            
            //Console.WriteLine("To string student:\n");
            //Console.WriteLine(student.ToString());
            Console.WriteLine("============================================================================================");
            Console.WriteLine(" \n");
            Console.ReadKey();



            studentCollection.SortAverageMark();
            Console.WriteLine("Average Mark:\n");
            Console.WriteLine(studentCollection.ToShortString());
            
            //Console.WriteLine("Person student:\n");
            //Console.WriteLine(student.Person);
            //Console.WriteLine("\n");
            Console.WriteLine("============================================================================================");
            Console.WriteLine(" \n");
            Console.ReadKey();

            //3
            //Вызвать методы класса StudentCollection, выполняющие операции со списком List<Student>, и после каждой операции вывести результат операции.Выполнить

            //вычисление максимального значения среднего балла для элементов списка;

            //фильтрацию списка для отбора студентов с формой обучения Education.Specialist;

            //группировку элементов списка по значению среднего балла; вывести все группы элементов.
            Console.WriteLine("Max Average Mark:\n");
            Console.WriteLine(studentCollection.MaxAverageMark());
            //Console.WriteLine("Making a copy...");
            // Console.WriteLine("Changing data...");
            Console.WriteLine("============================================================================================");
            Console.WriteLine(" \n");
            Console.ReadKey();


            Console.WriteLine("Specialist:\n");
            Console.WriteLine(string.Join("\n", studentCollection.ListOfSpec()));
            //Console.WriteLine("\n");
            //Student studentClone = (Student)student.DeepCopy();
            //student.Name = "Lizok";
            //student.Surname = "Cherry";
            //6
            //Console.WriteLine("New:");
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("Old:");
            //Console.WriteLine(studentClone.ToString());
            //7
            //Console.WriteLine("\n");
            Console.WriteLine("============================================================================================");
            Console.WriteLine(" \n");
            Console.ReadKey();


            Console.WriteLine("Students with Average Mark:\n");
            Console.WriteLine(string.Join("\n", studentCollection.AverageMarkGroup(3))); //заданное значение среднего балла
            //Console.WriteLine("Group change:");
            //try // присвоить свойству с номером группы неккоректное зачение
            //{
            //    student.GroupNumber = 12345;
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            Console.WriteLine("============================================================================================");
            Console.WriteLine(" \n");
            Console.ReadKey();



            TestCollections test = new TestCollections(4); //Создать объект типа TestCollections. Вызвать метод для поиска в коллекциях первого, центрального, последнего и элемента, не входящего в коллекции.Вывести значения времени поиска для всех четырех случаев. Вывод должен содержать информацию о том, к какой коллекции и к какому элементу относится данное значение.
            Console.WriteLine("\nTime to search: ");
            test.SearchTime();
            //8
            //foreach (var task in student.GetResults()) // список всех зачетов и экз
            //Console.WriteLine(task.ToString());

            Console.WriteLine("============================================================================================");


            //foreach (var task in student.GetExamsResults(3)) // экзамены выше 3 список
                //Console.WriteLine(task.ToString());
            Console.ReadKey();

        }
    }
}