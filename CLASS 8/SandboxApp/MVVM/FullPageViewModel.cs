﻿using System.ComponentModel;

namespace SandboxApp.MVVM
{
    public class FullPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                FullName = $"{FirstName} {LastName}";
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                FullName = $"{FirstName} {LastName}";
            }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }

        public FullPageViewModel()
        {
            FirstName = "Ivan";
            LastName = "Djikovski";
            FullName = FirstName + LastName;
        }
    }
}
