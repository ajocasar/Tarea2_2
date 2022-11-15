using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea2_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lista : ContentPage
    {
        public lista()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await App.BaseDatos.listaempleados();
        }

        private void ListaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.constructor item = (Models.constructor)e.Item;
            byte[] image = (byte[])item.imgM;
            ImageSource imageSource = null;
            imageSource = ImageSource.FromStream(() => new MemoryStream(image));

            imgFoto.Source = imageSource;
        }
    }
}