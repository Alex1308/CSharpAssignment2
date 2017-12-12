using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CSharpAssignment2
{
    public class PersistenceManager
    {

        private string fileName = "serials.txt";
        List<string> serialsFromFile = new List<string>();
        StorageFile serialFile;

        public PersistenceManager()
        {
            CreateFolderAsync();
        }

        private async void CreateFolderAsync()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var pFolder = await localFolder.CreateFolderAsync("pFolder", CreationCollisionOption.OpenIfExists);
            var files = await pFolder.GetFilesAsync();
            serialFile = files.FirstOrDefault(file => file.Name == fileName);

            IList<string> readSerials = await FileIO.ReadLinesAsync(serialFile);

            foreach (string s in readSerials)
            {
                serialsFromFile.Add(s);
            }
        }

        public bool AddToFolder()
        {

            return true;
        }

        public bool PCheckSerial(string serial)
        {
            bool found = false;

            Debug.WriteLine("Serial check persistence side" + serial);

            //Reverse through List to allow removal during iteration
            foreach (string x in serialsFromFile.Reverse<string>())
            {
                if (serial.Equals(x))
                {
                    serialsFromFile.Remove(x);
                    found = true;
                }
            }

            return found;
        }


        public async Task OnSuspendingAsync()
        {
            await FileIO.WriteLinesAsync(serialFile, serialsFromFile);
        }
    }
}
