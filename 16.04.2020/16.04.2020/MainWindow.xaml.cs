using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace _16._04._2020
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
            Person person = new Person();
            Student student = new Student();
            Teacher teacher = new Teacher();
            Random random = new Random();

            public class Person
            {
                public string name;
                public string surname;
                public int age;
            }

            public class Student : Person
            {
                public string group;
                public string Teacher;
            }
            public class Teacher : Person
            {
                public List<Student> list_student = new List<Student>();

                public void AddStudent(Student student)
                {
                    list_student.Add(student);
                }
            }



            public MainWindow()
            {
                InitializeComponent();
            }

            private void PersonsButton_Click(object sender, RoutedEventArgs e)
            {
                PersonNullPrint();
                StreamReader read = new StreamReader("Students.txt", true);
                string flag = "";
                string[] pers_arr;
                while (flag != null)
                {
                    flag = read.ReadLine();
                    if (flag != null)
                    {
                        pers_arr = flag.Split(' ');
                        person.surname = pers_arr[0];
                        person.name = pers_arr[1];
                        person.age = Convert.ToInt32(pers_arr[2]);
                        personPrint();
                    }
                }
                read.Close();
                read = new StreamReader("Teachers.txt", true);
                flag = "";
                while (flag != null)
                {
                    flag = read.ReadLine();
                    if (flag != null)
                    {
                        pers_arr = flag.Split(' ');
                        personReturn(pers_arr);
                        personPrint();
                    }
                }
                read.Close();
            }

            public void PersonNullPrint()
            {
                label1.Content = "Фамилия" + "\n";
                label2.Content = "Имя" + "\n";
                label3.Content = "Возраст" + "\n";
                label4.Content = "";
                label5.Content = "";
            }
            public void personPrint()
            {
                label1.Content += person.surname + "\n";
                label2.Content += person.name + "\n";
                label3.Content += person.age + "\n";
            }
            public void personReturn(string[] pers_arr)
            {

                person.surname = pers_arr[0];
                person.name = pers_arr[1];
                person.age = Convert.ToInt32(pers_arr[2]);
            }





            private void StudentsButton_Click(object sender, RoutedEventArgs e)
            {
                studentNullPrint();
                StreamReader read = new StreamReader("Students.txt", true);
                string flag = "";
                string[] st_arr;
                while (flag != null)
                {
                    flag = read.ReadLine();
                    if (flag != null)
                    {
                        st_arr = flag.Split(' ');
                        studentReturn(st_arr);
                        studentPrint();
                    }
                }
                read.Close();
            }

            public void studentReturn(string[] st_arr)
            {

                student.surname = st_arr[0];
                student.name = st_arr[1];
                student.age = Convert.ToInt32(st_arr[2]);
                student.group = st_arr[3];
                student.Teacher = st_arr[4];
            }

            public void studentNullPrint()
            {
                label1.Content = "Фамилия" + "\n";
                label2.Content = "Имя" + "\n";
                label3.Content = "Возраст" + "\n";
                label4.Content = "Группа" + "\n";
                label5.Content = "Учитель" + "\n";
            }

            public void studentPrint()
            {
                label1.Content += student.surname + "\n";
                label2.Content += student.name + "\n";
                label3.Content += student.age + "\n";
                label4.Content += student.group + "\n";
                label5.Content += student.Teacher + "\n";
            }






            public void RandomStudentButton_Click(object sender, RoutedEventArgs e)
            {
                studentNullPrint();
                StreamReader read = new StreamReader("Students.txt", true);
                string flag = "";
                int cnt = 0;
                string[] st_arr;
                while (flag != null)
                {
                    flag = read.ReadLine();
                    if (flag != null)
                    {
                        cnt++;
                    }
                }
                read.Close();
                int rnd = random.Next(0, cnt);
                int cnt2 = 0;
                read = new StreamReader("Students.txt", true);
                flag = "";
                while (flag != null)
                {
                    flag = read.ReadLine();
                    if (flag != null)
                    {
                        if (cnt2 == rnd)
                        {
                            st_arr = flag.Split(' ');
                            studentReturn(st_arr);
                            studentPrint();
                        }

                        cnt2++;
                    }
                }
                read.Close();
            }





            public void RandomPersonButton_Click(object sender, RoutedEventArgs e)
            {
                PersonNullPrint();
                int rnd = random.Next(1, 3);
                if (rnd == 1)
                {
                    StreamReader read = new StreamReader("Students.txt", true);
                    string flag = "";
                    int i = 0;
                    while (flag != null)
                    {
                        flag = read.ReadLine();
                        if (flag != null)
                        {
                            i++;
                        }
                    }
                    read.Close();
                    rnd = random.Next(0, i);
                    int cnt2 = 0;
                    read = new StreamReader("Students.txt", true);
                    flag = "";
                    string[] pers_arr;
                    while (flag != null)
                    {
                        flag = read.ReadLine();
                        if (flag != null)
                        {
                            if (cnt2 == rnd)
                            {
                                pers_arr = flag.Split(' ');
                                personReturn(pers_arr);
                                personPrint();
                            }

                            cnt2++;
                        }
                    }
                    read.Close();
                }
                else if (rnd == 2)
                {
                    StreamReader read = new StreamReader("Teachers.txt", true);
                    string flag = "";
                    int i = 0;
                    string[] pers_arr;
                    while (flag != null)
                    {
                        flag = read.ReadLine();
                        if (flag != null)
                        {
                            i++;
                        }
                    }
                    read.Close();
                    rnd = random.Next(0, i);
                    i = 0;
                    read = new StreamReader("Teachers.txt", true);
                    flag = "";
                    while (flag != null)
                    {
                        flag = read.ReadLine();
                        if (flag != null)
                        {
                            if (i == rnd)
                            {
                                pers_arr = flag.Split(' ');
                                personReturn(pers_arr);
                                personPrint();
                            }

                            i++;
                        }
                    }
                    read.Close();
                }
            }






            public void TeachersButton_Click(object sender, RoutedEventArgs e)
            {
                studentNullPrint();
                StreamReader read_tc = new StreamReader("Teachers.txt", true);
                string flag_tc = "";
                string[] tc_arr;
                string[] st_arr;
                while (flag_tc != null)
                {
                    flag_tc = read_tc.ReadLine();
                    if (flag_tc != null)
                    {
                        tc_arr = flag_tc.Split(' ');
                        teachersReturn(tc_arr);
                        teachersPrint();
                        StreamReader read_st = new StreamReader("Students.txt", true);
                        string flag_st = "";
                        teachersSkipPrint();

                        while (flag_st != null)
                        {
                            flag_st = read_st.ReadLine();
                            if (flag_st != null)
                            {
                                st_arr = flag_st.Split(' ');
                                if (st_arr[4] == teacher.surname)
                                {
                                    studentReturn(st_arr);
                                    teacher.AddStudent(this.student);
                                    studentPrint();
                                }
                            }
                        }
                        read_st.Close();
                    }
                }
                read_tc.Close();
            }
            public void teachersReturn(string[] tc_arr)
            {
                teacher.surname = tc_arr[0];
                teacher.name = tc_arr[1];
                teacher.age = Convert.ToInt32(tc_arr[2]);
            }

            public void teachersSkipPrint()
            {
                label1.Content += "Студенты: \n";
                label2.Content += "\n";
                label3.Content += "\n";
                label4.Content += "\n";
                label5.Content += "\n";
            }

            public void teachersPrint()
            {
                label1.Content += "\n" + teacher.surname + "\n";
                label2.Content += "\n" + teacher.name + "\n";
                label3.Content += "\n" + teacher.age + "\n";
                label4.Content += "\n" + "\n";
                label5.Content += "\n" + "\n";
            }
        }
    
}
