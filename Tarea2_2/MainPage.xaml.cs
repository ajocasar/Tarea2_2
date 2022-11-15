using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Tarea2_2.Models;



namespace Tarea2_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            
            var path = System.IO.Path.Combine("", "FirmaTest.jpg");

            Stream image_= await   padView.GetImageStreamAsync(SignatureImageFormat.Jpeg);
            BinaryReader br = new BinaryReader(image_);
            br.BaseStream.Position = 0;
            Byte[] All = br.ReadBytes((int)image_.Length);


            if ( String.IsNullOrWhiteSpace(txtDescripcion.Text) || String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                await DisplayAlert("Error Introducciendo los datos", "¡Llenar todos los campos!", "OK");
            }
            else
            {
                var emple = new constructor
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text,
                    imgM = (byte[])All
                
            };
                var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
                if (resultado != 0)
                {
                    await DisplayAlert("Alerta", "¡Firma Guardada con éxito!", "OK");
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    padView.Clear();

                }
                else
                {
                    await DisplayAlert("Alerta", "¡Los datos no se guardaron!", "OK");
                }
            }
                                                              
        }
      
        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            var newpage = new lista();
            await Navigation.PushAsync(newpage);
        }
    }
}
