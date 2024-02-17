using System;
using Angajati.Models;

namespace Angajati
{
    public partial class AngajatPage : ContentPage
    {
        public AngajatPage()
        {
            InitializeComponent();
            BindingContext = new Angajat();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajat)BindingContext;
            
            await App.AngajatDatabase.SaveAngajatAsync(angajat);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajat)BindingContext;
            
            await App.AngajatDatabase.DeleteAngajatAsync(angajat);
            await Navigation.PopAsync();
        }
    }
}
