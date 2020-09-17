using System;


namespace Poject_Phons.BusinessLogic.Models
{
    [Serializable]
    public class Characteristic
    {
        public string Screen { get; }
        public string Camera { get; }
        public string Memory { get; }
        public string Hardware { get; }
        public string Battery { get; }

        public string [] Print { get; }

        public Characteristic() { }
        public Characteristic(string screen, string camera, string memory, string hardware, string battery)
        {
            if (string.IsNullOrWhiteSpace(screen))
                throw new ArgumentNullException("Поле не может быть пустым или null", nameof(screen));
            if (string.IsNullOrWhiteSpace(camera))
                throw new ArgumentNullException("Поле не может быть пустым или null", nameof(camera));
            if (string.IsNullOrWhiteSpace(memory))
                throw new ArgumentNullException("Поле не может быть пустым или null", nameof(memory));
            if (string.IsNullOrWhiteSpace(hardware))
                throw new ArgumentNullException("Поле не может быть пустым или null", nameof(hardware));
            if (string.IsNullOrWhiteSpace(battery))
                throw new ArgumentNullException("Поле не может быть пустым или null", nameof(battery));
            Screen = screen;
            Camera = camera;
            Memory = memory;
            Hardware = hardware;
            Battery = battery;

            Print = new string[] { Screen, Camera, Memory, Hardware, Battery };
        }
    }
}
