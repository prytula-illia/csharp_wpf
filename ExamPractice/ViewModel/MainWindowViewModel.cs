using ExamPractice.Commands;
using ExamPractice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPractice.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private StudentContext db;

        public ObservableCollection<StudentViewModel> Students { get; set; }

        public MainWindowViewModel()
        {
            db = new StudentContext();
            db.Students.Load();

            Students = new ObservableCollection<StudentViewModel>();

            foreach (var s in db.Students)
            {
                Students.Add(new StudentViewModel(s));
            }
        }
        ~MainWindowViewModel()
        {
            db.Dispose();
        }

        public ICommand UpdateDB
        {
            get
            {
                return new Command((obj) =>
                {
                    db.SaveChanges();
                });
            }
        }

      
        public ICommand AddToDB
        {
            get
            {
                return new Command((obj) =>
                {
                    var mw = (MainWindow)obj;

                    string name = mw.NameTBox.Text;
                    string surname = mw.SurameTBox.Text;
                    DateTime dt = Convert.ToDateTime(mw.DateOfBirthTBox.Text);
                    long passId = Convert.ToInt64(mw.PassNumberTBox.Text);

                    Student s = new Student() { Name = name, Surname = surname, DateOfBirth = dt, PassNumber = passId };
                    Students.Add(new StudentViewModel(s));
                    db.Students.Add(s);
                    db.SaveChanges();
                });
            }
        }

        public ICommand DeleteFromDB
        {
            get
            {
                return new Command((obj) =>
                {
                    var mw = (MainWindow)obj;
                    var allDataGrid = mw.allDataGrid;
                    if (allDataGrid.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < allDataGrid.SelectedItems.Count; i++)
                        {
                            StudentViewModel s = allDataGrid.SelectedItems[i] as StudentViewModel;

                            if (s != null)
                            {
                                Student deletedS = db.Students.Find(s.Id);
                                if (deletedS != null)
                                {
                                    db.Students.Remove(deletedS);
                                }
                            }
                            Students.Remove(s);
                        }
                    }

                    db.SaveChanges();
                });
            }
        }
    }

}
