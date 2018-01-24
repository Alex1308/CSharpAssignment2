using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GUIProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            verifier = new InputVerification();
            datePickerInput.MaxDate = DateTime.Now;
            listView.ItemsSource = PersistenceManager.Instance.people;
        }



        private InputVerification verifier;


        private async void ConfirmInput(object sender, RoutedEventArgs e)
        {
            try
            {
                Person person = new Person(firstNameInput.Text, surNameInput.Text, emailAddressInput.Text, phoneNumberInput.Text, (DateTimeOffset)datePickerInput.Date, serialNumberInput.Text);
                if (await verifier.VerifyInput(person))
                {
                    //Create confirmation box and create person
                    //The pop up window is too small, but I haven't been able to figure out why and decided to leave it as is, since GUI was unimportant
                    if (!confirmationBox.IsOpen)
                    {
                        confirmationBox.IsOpen = true;
                    }

                    //Clear input boxes
                    firstNameInput.Text = String.Empty;
                    surNameInput.Text = String.Empty;
                    emailAddressInput.Text = String.Empty;
                    phoneNumberInput.Text = String.Empty;
                    serialNumberInput.Text = String.Empty;
                    datePickerInput.Date = null;
                    //Clearing done

                    PersistenceManager.Instance.AddPerson(person);
                }
                else
                {
                    //Display error message
                    //The pop up window is too small, but I haven't been able to figure out why and decided to leave it as is, since GUI was unimportant
                    errorText.Text = "One of your entries are wrong. Please double check your input.";
                    if (!errorBox.IsOpen)
                    {
                        errorBox.IsOpen = true;
                    }
                }
            }
            catch (Exception)
            {
                //Error message - please enter something in all fields
                //The pop up window is too small, but I haven't been able to figure out why and decided to leave it as is, since GUI was unimportant
                errorText.Text = "Please enter something in every input field.";
                if (!errorBox.IsOpen)
                {
                    errorBox.IsOpen = true;
                }
            }

        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (confirmationBox.IsOpen)
            {
                confirmationBox.IsOpen = false;
            }
        }

        private void CloseErrorClicked(object sender, RoutedEventArgs e)
        {
            if (errorBox.IsOpen)
            {
                errorBox.IsOpen = false;
            }
        }
    }
}
