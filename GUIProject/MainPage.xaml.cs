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
            List<string> tempList = new List<string>();
            tempList.Add(firstNameInput.Text);
            tempList.Add(surNameInput.Text);
            tempList.Add(emailAddressInput.Text);
            tempList.Add(phoneNumberInput.Text);
            tempList.Add(datePickerInput.Date.ToString());
            tempList.Add(serialNumberInput.Text);

            tempList.ForEach(x =>
            {
                Debug.WriteLine(x);
            });


        }
    }
}
