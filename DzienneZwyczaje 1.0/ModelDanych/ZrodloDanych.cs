using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using Windows.Storage;
using System.Windows.Input;
using DzienneZwyczaje_1._0.Komendy;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace DzienneZwyczaje_1._0.ModelDanych
{

    public class Zwyczaj : INotifyPropertyChanged
    {
        
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int Max { get; set; }
        public ObservableCollection<DateTime> Daty { get; set; }

        [IgnoreDataMember]
        public ICommand KompletnaKomenda { get; set; }
        [IgnoreDataMember]
        public ICommand UsunZwyczaj { get; set; }

        public Zwyczaj()
        {
            KompletnaKomenda = new KompletneBtnClick();
            UsunZwyczaj = new UsunBtnClick();
            Daty = new ObservableCollection<DateTime>();
        }

       

        public void DodajDate()
        {
            Daty.Add(DateTime.Today);
            NotifyPropertyChanged("Daty");
        }

      
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ZrodloDanych
    {
        private ObservableCollection<Zwyczaj> _zwyczaje;

        const string nazwaPliku = "zwyczaje.json";
        public ZrodloDanych()
        {
            _zwyczaje = new ObservableCollection<Zwyczaj>();
        }
        
        public async Task<ObservableCollection<Zwyczaj>> PobierzZwyczaje()
        {
            await LadowanieDanych();
            return _zwyczaje;
        }
        private async Task LadowanieDanych()
        {
            if (_zwyczaje.Count == 0)
                await LadujDaneAsync();

            return;
        }

        private async Task LadujDaneAsync()
        {
            if (_zwyczaje.Count != 0)
                return;

            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Zwyczaj>));

            try
            {
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(nazwaPliku))
                {
                    _zwyczaje = (ObservableCollection<Zwyczaj>)jsonSerializer.ReadObject(stream);
                }
            }
            catch
            {
                _zwyczaje = new ObservableCollection<Zwyczaj>();
            }
        }

        public async void DodajZwyczaj(string nazwa, string opis, int max)
        {
            var zwyczaj = new Zwyczaj();
            zwyczaj.Nazwa = nazwa;
            zwyczaj.Opis = opis;
            zwyczaj.Max = max;
            zwyczaj.Daty = new ObservableCollection<DateTime>();

            _zwyczaje.Add(zwyczaj);
            await ZapiszDaneAsync();
        }
        public async void UsunZwyczaj (Zwyczaj zwyczaj)
        {
            _zwyczaje.Remove(zwyczaj);
            await ZapiszDaneAsync();
        }

        private async Task ZapiszDaneAsync()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Zwyczaj>));
            using(var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(nazwaPliku,
                CreationCollisionOption.ReplaceExisting))
            {
                jsonSerializer.WriteObject(stream, _zwyczaje);
            }
        }

        public async void UkonczonyZwyczajDzis(Zwyczaj zwyczaj)
        {
            int index = _zwyczaje.IndexOf(zwyczaj);
            _zwyczaje[index].DodajDate();
            await ZapiszDaneAsync();
           
            
        }
    }
}
