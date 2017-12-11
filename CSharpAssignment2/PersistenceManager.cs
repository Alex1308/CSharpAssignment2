using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CSharpAssignment2
{
    class PersistenceManager
    {



        public PersistenceManager()
        {
        }

        private async void CreateFolder()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var pFolder = await localFolder.CreateFolderAsync("pFolder", CreationCollisionOption.OpenIfExists);
        }

        public bool AddToFolder()
        {

            return true;
        }

    }
}
