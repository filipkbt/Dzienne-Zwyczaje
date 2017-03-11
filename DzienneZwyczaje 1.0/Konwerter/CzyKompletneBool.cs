using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DzienneZwyczaje_1._0.Konwerter
{
    class CzyKompletneBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ObservableCollection<DateTime> daty = (ObservableCollection<DateTime>)value;

            if (daty.Contains(DateTime.Today))
            {
                return false;
               
            }


            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
