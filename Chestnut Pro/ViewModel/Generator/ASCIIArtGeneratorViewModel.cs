﻿
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Chestnut_Pro.Model;

namespace Chestnut_Pro.ViewModel
{
    public class ASCIIArtGeneratorViewModel : INotifyPropertyChanged
    {
        public ASCIIArtGeneratorViewModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
