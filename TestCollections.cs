using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab3

    /*Во всех вариантах лабораторной работы 3 требуется определить класс TestCollections, который содержит поля следующих типов

System.Collections.Generic.List<TKey> ;

System.Collections.Generic.List<string> ;

System.Collections.Generic.Dictionary<TKey, TValue> ;

System.Collections.Generic.Dictionary<string, TValue> .*/



{
    internal class TestCollections
    {
        private List<Person> Persons 
        { 
            get;
            set; 
        }
        private List<string> Text
        {
            get;
            set;
        }
        private Dictionary<Person, Student> PersStudDictionary
        { 
            get;
            set;
        }
        private Dictionary<string, Student> StrStudDictionary
        { 
            get;
            set;
        }

        public static Student Studentin(int zn) //статический метод с одним целочисленным параметром типа int, который возвращает ссылку на объект типа Student и используется для автоматической генерации элементов коллекций;
        {
            Student student = new Student(new Person("Name" + zn, "Surname" + zn, DateTime.Today.AddMonths(-zn)), Education.Bachelor, (zn % 5) * 100 + zn);
            student.AddExams(new Exam("Exam " + zn, zn % 5, DateTime.Today.AddMonths(-zn + 3)), new Exam("Exam " + zn + 1, (zn + 1) % 5, DateTime.Today.AddDays(-zn + 2)), new Exam("Exam " + zn + 2, (zn + 2) % 5, DateTime.Today.AddYears(-zn)));
            student.AddTests(new Test("Test " + zn, zn % 2 == 0 ? true : false), new Test("Test " + zn + 1, (zn + 1) % 2 == 0 ? false : true), new Test("Test " + zn + 2, (zn + 2) % 2 == 0 ? true : false));
            return student;
        }

        public TestCollections(int c) //конструктор c параметром типа int (число элементов в коллекциях) для автоматического создания коллекций с заданным числом элементов;
        {
            Persons = new List<Person>();
            Text = new List<string>();
            PersStudDictionary = new Dictionary<Person, Student>();
            StrStudDictionary = new Dictionary<string, Student>();

            for (int i = 0; i < c; i++)
            {
                Student student = Studentin(i);
                Person person = student.Person;
                Persons.Add(person);
                Text.Add(person.ToString());
                PersStudDictionary.Add(person, student);
                StrStudDictionary.Add(person.ToString(), student);
            }

        }


        public void SearchTime() //метод, который вычисляет время поиска элемента в списках List<Person> и List<string>, время поиска элемента по ключу и время поиска элемента по значению в коллекциях-словарях Dictionary<Person, Student> и Dictionary<string, Student>.
        {
            int dl = Persons.Count - 1;
            int[] indexes = { 0, dl, dl / 2, dl + 1 };
            foreach (var zn in indexes)
            {
                var searcherStudent = Studentin(zn);
                var searcherPerson = searcherStudent.Person;

                Console.WriteLine("============================================================================================");

                var time = Stopwatch.StartNew();
                var ms = Persons.Contains(searcherPerson);
                time.Stop();
                Console.WriteLine("List Person {0}: " + time.Elapsed + "\n {1}", zn, ms);

                time = Stopwatch.StartNew();
                ms = Text.Contains(searcherPerson.ToString());
                time.Stop();
                Console.WriteLine("List Person toString {0}: " + time.Elapsed + "\n {1}", zn, ms);

                time = Stopwatch.StartNew();
                ms = PersStudDictionary.ContainsKey(searcherPerson);
                time.Stop();
                Console.WriteLine("Dictionary<Person, Student> Key {0}: " + time.Elapsed + "\n {1}", zn, ms);

                time = Stopwatch.StartNew();
                ms = PersStudDictionary.ContainsValue(searcherStudent);
                time.Stop();
                Console.WriteLine("Dictionary<Person, Student> Value{0}: " + time.Elapsed + "\n {1}", zn, ms);

                time = Stopwatch.StartNew();
                ms = StrStudDictionary.ContainsKey(searcherPerson.ToString());
                time.Stop();
                Console.WriteLine("Dictionary<string, Student> Key {0}: " + time.Elapsed + "\n {1}", zn, ms);

                time = Stopwatch.StartNew();
                ms = StrStudDictionary.ContainsValue(searcherStudent);
                time.Stop();
                Console.WriteLine("Dictionary<string, Student> Value {0}: " + time.Elapsed + "\n {1}", zn, ms);
            }
        }
    }
}
