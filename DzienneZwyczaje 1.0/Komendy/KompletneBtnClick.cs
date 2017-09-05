using DzienneZwyczaje_1._0.ModelDanych;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace DzienneZwyczaje_1._0.Komendy
{
    class KompletneBtnClick : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.ModelDanych.UkonczonyZwyczajDzis((Zwyczaj)parameter);
        }
    }
}
