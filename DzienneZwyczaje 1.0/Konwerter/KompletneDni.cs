using DzienneZwyczaje_1._0.ModelDanych;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DzienneZwyczaje_1._0.Konwerter
{
    class KompletneDni : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
                ObservableCollection<DateTime> Daty = (ObservableCollection<DateTime>)value;

                return Daty.Count;           
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
