using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace CSharpAssignment2
{
    public class PersistenceManager
    {

        private string serialFileName = "serials.txt";
        private string xmlFileName = "people.xml";
        public List<Person> people { get; set; }
        List<string> serialsFromFile = new List<string>();
        StorageFile serialFile;
        StorageFile xmlFile;
        StorageFolder pFolder;

        /// <summary>
        /// Singleton Pattern implementation
        /// </summary>
        private static PersistenceManager instance;
        public static PersistenceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersistenceManager();
                }
                return instance;
            }
        }
        private PersistenceManager()
        {
        }

        public async void Initialise()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            pFolder = await localFolder.CreateFolderAsync("pFolder", CreationCollisionOption.OpenIfExists);
            var files = await pFolder.GetFilesAsync();
            serialFile = files.FirstOrDefault(file => file.Name == serialFileName);
            people = new List<Person>();
            try
            {
                await ReadFromXml();
            }
            catch (Exception)
            {
            }

            IList<string> readSerials = await FileIO.ReadLinesAsync(serialFile);
            foreach (string s in readSerials)
            {
                serialsFromFile.Add(s);
            }

        }

        public void AddPerson(Person person)
        {
            people.Add(person);
        }

        public bool PCheckSerial(string serial)
        {
            bool found = false;

            //Reverse through List to allow removal during iteration
            foreach (string x in serialsFromFile.ToList())
            {
                if (serial == x)
                {
                    serialsFromFile.RemoveAll(s => s == serial);
                    found = true;
                }
            }

            return found;
        }

        public async Task ReadFromXml()
        {
            List<Person> deserializedPeople = default(List<Person>);
            var deserializer = new XmlSerializer(typeof(List<Person>));
            var files = await pFolder.GetFilesAsync();
            xmlFile = files.FirstOrDefault(file => file.Name == xmlFileName);
            Stream stream = await xmlFile.OpenStreamForReadAsync();
            deserializedPeople = (List<Person>)deserializer.Deserialize(stream);
            stream.Dispose();
            people = deserializedPeople;
        }

        public async void SavePersonXMLAsync()
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            StorageFile file = await pFolder.CreateFileAsync(xmlFileName, CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();

            using (stream)
            {
                serializer.Serialize(stream, people);
            }
        }

        public List<string> PrintPeople()
        {
            List<string> stringifiedPeople = new List<string>();
            foreach (var person in people)
            {
                stringifiedPeople.Add(person.ToString());
            }
            return stringifiedPeople;
        }


        public async Task OnSuspendingAsync()
        {
            await FileIO.WriteLinesAsync(serialFile, serialsFromFile);
        }
    }
}
