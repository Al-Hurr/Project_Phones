using System;



namespace Poject_Phons.BusinessLogic.Models
{
    [Serializable]
    public class Phone
    {
        public string Name { get; }

        public Phone(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Ползователь не может быть равен null или пуcтым");
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
