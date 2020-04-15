using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SR5
{
    internal class Program
    {
        private static Random rnd = new Random();
        
        public static void Main(string[] args)
        {
            List<ControlElement> works = new List<ControlElement>();
            for (int i = 0; i < 5; i++)
            {
                if (rnd.Next(2) == 0)
                {
                    works.Add(new Contest(rnd.Next(81), "Contest" + (char)rnd.Next(100), rnd.Next(1, 11)));
                }
                else
                {
                    works.Add(new ControlWork(rnd.Next(81), "Contest" + (char)rnd.Next(100), rnd.Next(0, 100)));
                }
            }
            Student student = new Student("Gena", "Gorin", works);
            
            XmlSerializer ser = new XmlSerializer(typeof(Student));
            try
            {
                using (FileStream fs = new FileStream("../../VisibleXml.xml", FileMode.Create))
                {
                    ser.Serialize(fs, student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    public class ControlElement
    {
        public int weight;
        public string name;

        public ControlElement(int weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }
    }

    public class Contest : ControlElement
    {
        public int tasksNumber;


        public Contest(int weight, string name, int tasksNumber) : base(weight, name)
        {
            this.tasksNumber = tasksNumber;
        }
    }

    public class ControlWork : ControlElement
    {
        public int variant;

        public ControlWork(int weight, string name, int variant) : base(weight, name)
        {
            this.variant = variant;
        }
    }

    public class Student
    {
        public string name;
        public string surname;
        public List<ControlElement> works=new List<ControlElement>();
        
        public Student(string name, string surname, List<ControlElement> works)
        {
            this.name = name;
            this.surname = surname;
            this.works = works;
        }
    }
}