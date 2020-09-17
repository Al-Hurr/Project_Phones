using System;

namespace Poject_Phons.BusinessLogic.Models
{
    [Serializable]
    public class Model
    {
        public Phone Phone { get; }

        public string Name { get; }

        public Characteristic Characteristic  { get; private set; }

        public Model(Phone phone,  string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя модели не может быть пустым", nameof(name));
            Phone = phone ?? throw new ArgumentNullException("Пользователь не может быть пустым",nameof(phone));
           
            Name = name;
        }
        public void AddCharacter(Characteristic characteristic)
        {
            Characteristic = characteristic ?? throw new ArgumentNullException("Характеристика не может быть пустым", nameof(characteristic));
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
