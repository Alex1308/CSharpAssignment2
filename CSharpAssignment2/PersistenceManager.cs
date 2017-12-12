using System;
using System.Collections.Generic;
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
            CreateFolder();
        }

        private async void CreateFolder()
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



            serialsFromFile.ForEach(x =>
            {
                if (serial.Equals(x))
                {
                    //Remove serial from txt file using LinQ
                    serialsFromFile.Remove(x);
                    found = true;
                }
            });

            //With such a small text file it is okay to write the entire list of strings after removing the used up serial number

            return found;
        }


        public void OnSuspending()
        {
             FileIO.WriteLinesAsync(serialFile, serialsFromFile);
        }
    }
}
