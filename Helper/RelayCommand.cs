﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaltAirAtlantique.Helper
{
    public class RelayCommand: ICommand
    {
        private readonly Action _actionAExecuter = null;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            _actionAExecuter = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _actionAExecuter();
        }
    }
}

