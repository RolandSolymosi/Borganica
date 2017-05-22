using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Borganica.Models
{
    public class Project : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
