using CSharpAssignment2;
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
        }

        private InputVerification verifier;


        private async void ConfirmInput(object sender, RoutedEventArgs e)
        {
            Person person = new Person(firstNameInput.Text, surNameInput.Text, emailAddressInput.Text, phoneNumberInput.Text, (DateTimeOffset)datePickerInput.Date, serialNumberInput.Text);

            if (!(String.IsNullOrWhiteSpace(firstNameInput.Text)
                & String.IsNullOrWhiteSpace(surNameInput.Text)
                & String.IsNullOrWhiteSpace(emailAddressInput.Text)
                & String.IsNullOrWhiteSpace(phoneNumberInput.Text)
                & String.IsNullOrWhiteSpace(serialNumberInput.Text)
                & datePickerInput.Date == null))
            {
                if (await verifier.VerifyInput(person))
                {
                    //Create confirmation box and create person
                    PersistenceManager.Instance.AddPerson(person);
                }
                else
                {
                    //Display error message
                }
            }
            else
            {
                //Error message - please enter something in all fields
            }

        }
    }
}
