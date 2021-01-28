using ExamPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice.ViewModel
{
    class StudentViewModel : BaseViewModel
    {
        private readonly Student student;

        public StudentViewModel() { }
        public StudentViewModel(Student student)
        {
            this.student = student;
        }

        public int Id 
        { 
            get
            {
                return student.Id;
            }
            set
            {
                student.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get
            {
                return student.Name;
            }
            set
            {
                student.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get
            {
                return student.Surname;
            }
            set
            {
                student.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return student.DateOfBirth;
            }
            set
            {
                student.DateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public long PassNumber
        {
            get
            {
                return student.PassNumber;
            }
            set
            {
                student.PassNumber = value;
                OnPropertyChanged(nameof(PassNumber));
            }
        }
    }
}
