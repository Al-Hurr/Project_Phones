using Poject_Phons.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Poject_Phons.BusinessLogic.Controlers
{
    public class PhonesController:BaseController
    {
        private const string PHONES_DATA = "phones.dat";
        public List<Phone> Phones { get; private set; }
        public Phone current_phone { get; private set; }

        public bool newPhone { get; private set; } = false;

        public PhonesController()
        {
            Phones = GetPhones();
            
        }

        public void RemovePhone(int index, bool ModelsEnded = false)
        {
            Phones.RemoveAt(index);
            Save();
            if (ModelsEnded)
            {
                FileInfo fileInfo = new FileInfo(current_phone.Name);
                if (fileInfo.Exists)
                    fileInfo.Delete();
            }
        }

        public void AddnSetCurrent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя не может быть пустым или null");

            Phones = GetPhones();

            current_phone = Phones.SingleOrDefault(x => x.Name == name);
            if (current_phone == null)
            {
                current_phone = new Phone(name);
                Phones.Add(current_phone);
                newPhone = true;
                Save();
            }

        }

        

        private void Save()
        {
            Save(PHONES_DATA,Phones);
        }

        private List<Phone> GetPhones()
        {
            return Load <List<Phone >>(PHONES_DATA) ?? new List<Phone>();
        }
    }
}
