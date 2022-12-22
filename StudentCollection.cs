using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab3

//Определить класс StudentCollection, который содержит

{
    internal class StudentCollection
    {
        private List<Student> students = new List<Student>(); //закрытое поле типа System.Collections.Generic.List<Student>;
        public void AddDefaults() //метод void AddDefaults(), c помощью которого можно добавить некоторое число элементов типа Student для инициализации коллекции по умолчанию;
        {
            Student[] defaul = new Student[3];
            // DateTime date = new DateTime(2003, 12, 25); 
            defaul[0] = new Student(new Person("Eloise", "Rybko", new DateTime(2003, 12, 25)), Education.Bachelor, 1521);
            defaul[0].AddExams(new Exam("Math", 4, new DateTime(2023, 01, 11)));
            defaul[0].AddTests(new Test("Deutch", true));
            defaul[1] = new Student(new Person("Liza", "Vishnya", new DateTime(2002, 08, 11)), Education.Specialist, 1521);
            defaul[1].AddExams(new Exam("Sety", 3, new DateTime(2023, 01, 17)));
            defaul[1].AddTests(new Test("IskInt", true));
            defaul[2] = new Student(new Person("Elr", "Cherrysse", new DateTime(2017, 01, 01)), Education.Bachelor, 1521);
            defaul[2].AddExams(new Exam("OOP", 5, new DateTime(2023, 01, 14)));
            defaul[2].AddTests(new Test("Fizra", false));
            students.AddRange(defaul);
        }

        public void AddStudents(params Student[] range) //метод void AddStudents (params Student[] ) для добавления элементов в список List<Student>;
        {
            students = new List<Student>();
            foreach (var stud in range)
            {
                students.Add(stud);
            }
        }

        public override string ToString() //перегруженную версию виртуального метода string ToString() для формирования строки c информацией обо всех элементах списка List<Student>, включающую значения всех полей, список зачетов и экзаменов для каждого элемента Student;
        {
            string temp = "";
            for (int i = 0; i < students.Count; i++)
                temp += "\nName " + students[i].Name + "\nSurname " + students[i].Surname + "\nDate of birth: " + students[i].Date + students[i].ToString() + "\n";
            return temp;
        }

        public virtual string ToShortString() //метод string ToShortString(), который формирует строку c информацией обо всех элементах списка List<Student>, содержащую значения всех полей, средний балл, число зачетов и число экзаменов для каждого элемента Student, но без списков зачетов и экзаменов.
        {
            string temp = "";
            for (int i = 0; i < students.Count; i++)
                temp += "\nName: " + students[i].Name + "\nSurname: " + students[i].Surname + "\nDate of Birth: " + students[i].Date + "\nEducation: " + students[i].Education + "\nGroup: " + students[i].GroupNumber + "\nPassed exams: " + students[i].Exams.Count + "\nAveradge Mark: " + students[i].AverageMark + "\nPassed tests: " + students[i].Tests.Count + "\n";
            return temp;
        }


        //Вклассе StudentCollection определить методы, выполняющие сортировку списка List<Student>


        public void SortSurname() //по фамилии студента
        {
            students.Sort();
        }


        public void SortDate() //по дате рождения студента
        {
            students.Sort((x, y) => new Student().Compare(x, y));
        }

        public void SortAverageMark()
        {
            students.Sort((x, y) => new AverageMarkComparer().Compare(x, y));
        }

        public double MaxAverageMark() //по среднему баллу
        {
            return students.Count != 0 ? students.Select(x => x.AverageMark).Max() : 0;
        }

        public List<Student> AverageMarkGroup(double value) //метод List<Student> AverageMarkGroup(double value), который возвращает список, в который входят элементы Student из списка List<Student> с заданным значением среднего балла; для формирования списка
        {
            IEnumerable<IGrouping<double, Student>> group = students.GroupBy(item => item.AverageMark);


            foreach (IGrouping<double, Student> item in group)
            {
                if (item.Key == value)
                {
                    return item.ToList<Student>();
                }
            }

            return new List<Student>();
        }


        public IEnumerable<Student> ListOfSpec() //свойство типа IEnumerable<Student>, возвращающее подмножество элементов списка List<Student> с формой обучения Education.Specialist; для формирования подмножества использовать метод Where класса System.Linq.Enumerable;
        {
            return students.Where(x => x.Education == Education.Specialist);
        }

       /* public List<Student> Students { 
            get { 
                return students;
            } 
            set {
                students = value; 
            }
        }*/

    }
}

