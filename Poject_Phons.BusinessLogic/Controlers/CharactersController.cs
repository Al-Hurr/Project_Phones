using Poject_Phons.BusinessLogic.Models;
using System;
using System.IO;

namespace Poject_Phons.BusinessLogic.Controlers
{
    public class CharactersController:BaseController
    {
        public Characteristic Characteristic { get; private set; }
       
        public string modelName { get; }
        public CharactersController(string modelname)
        {
            modelName = modelname;
            Characteristic = GetCharacteristick();

        }
        
        public void Add(Characteristic characteristic)
        {
            Characteristic = characteristic;
            Save();
        }
        public void Remove()
        {
            FileInfo fileInfo = new FileInfo(modelName);
            if (fileInfo.Exists)
                fileInfo.Delete();
        }

        private void Save()
        {
            Save(modelName, Characteristic);
        }

        private Characteristic GetCharacteristick()
        {
            return Load<Characteristic>(modelName) ?? new Characteristic();
        }
    }
}
