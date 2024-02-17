using System;
using Angajati.Models;

namespace Angajati
{
    public partial class AngajatEntryPage : ContentPage
    {
        public AngajatEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.AngajatDatabase.GetAngajatiAsync();
        }

        async void OnAngajatAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatPage
            {
                BindingContext = new Angajat()
            });
        }

        async void OnAddAngajatClicked(object sender, EventArgs e)
        {
            
            Angajat angajat = new Angajat
            {
                Prenume = entryPrenume.Text,
                Nume = entryNume.Text,
                Email = entryEmail.Text,
                Data_nasterii = datePicker.Date
            };

            
            await App.AngajatDatabase.SaveAngajatAsync(angajat);

            
            listView.ItemsSource = await App.AngajatDatabase.GetAngajatiAsync();

           
            entryPrenume.Text = entryNume.Text = entryEmail.Text = string.Empty;
            datePicker.Date = DateTime.Now;
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AngajatPage
                {
                    BindingContext = e.SelectedItem as Angajat
                });
            }
        }
    }
}
