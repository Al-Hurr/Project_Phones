using Poject_Phons.BusinessLogic.Controlers;
using Poject_Phons.BusinessLogic.Models;
using System;

//ПРОГРАММА ДОБАВЛЕНИЯ, ПРОСМОТРА, УДАЛЕНИЯ ХАРАКТЕРИСТИК СМАРТФОНОВ.

namespace Project_Phones.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones_ctrl = new PhonesController();
            

            

            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("A - Ввести новый смартфон.\tB - Вывести список смартфонов.\tD - Удалить смартфон\tQ - Выход.");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        SetNewDevice(phones_ctrl);
                        break;

                    case ConsoleKey.B:
                        PrintDevice(phones_ctrl);
                        
                        break;

                    case ConsoleKey.D:
                        RemoveDevice(phones_ctrl);
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод.");
                        break;
                }
                
                
                
                
            }
        }

        private static void RemoveDevice(PhonesController phones_ctrl)
        {
            Console.Clear();
            Console.WriteLine("Выберите название и нажмите Enter:");
            //Если список смартфонов пуст, возвращаемся в меню
            if (phones_ctrl.Phones.Count == 0)
            {
                Console.WriteLine("Список смартфонов пуст. Нажмите Enter чтобы продолжить.");
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < phones_ctrl.Phones.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {phones_ctrl.Phones[i]}");
            }
            int numPhoneforRemove;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numPhone) && numPhone <= phones_ctrl.Phones.Count)
                {
                    numPhoneforRemove = numPhone - 1;
                    var phoneName = phones_ctrl.Phones[numPhone - 1].Name;
                    Console.WriteLine($"Вы выбрали: {phoneName}");
                    phones_ctrl.AddnSetCurrent(phoneName);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }


            var models_controller = new ModelsController(phones_ctrl.current_phone);

            if (models_controller.Models.Count == 0)
            {
                Console.WriteLine($"У {phones_ctrl.current_phone.Name} не найдено моделей. Нажмите любую кнопку чтобы продолжить.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Для удаления выберите модель и нажмите Enter.");
            //models_controller.RemoveModel(2);
            for (int i = 0; i < models_controller.Models.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {models_controller.Models[i]}");
            }
            string modelName;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numModel) && numModel <= models_controller.Models.Count)
                {
                    
                    modelName = models_controller.Models[numModel - 1].Name;
                    models_controller.RemoveModel(numModel - 1);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            

            var characteristicksCtrl = new CharactersController(modelName);
            characteristicksCtrl.Remove();
            if (models_controller.Models.Count == 0)
            {
                phones_ctrl.RemovePhone(numPhoneforRemove,true);


            }
            Console.WriteLine($"Модель {modelName} удален. Нажмите Enter кнопку чтобы продолжить.") ;
            Console.ReadLine();
        }

        private static void SetNewDevice(PhonesController phones_ctrl)
        {
            Console.WriteLine("Введите название смартфона: ");
            string smartName;
            while (true)
            {
                smartName = Console.ReadLine();
                if (string.IsNullOrEmpty(smartName))
                {
                    Console.WriteLine("Название не может быть пустым.");
                }
                else
                {
                    break;
                }
            }
            
            phones_ctrl.AddnSetCurrent(smartName);
          

            Console.WriteLine($"Введите модель {smartName}:");
            var modelName = Console.ReadLine();
            
            var model = new Model(phones_ctrl.current_phone, modelName);
            var model_ctrl = new ModelsController(phones_ctrl.current_phone);
            model_ctrl.Add(model);

            if (!model_ctrl.newModel)
            {
                Console.WriteLine("Вы ввели существующую модель. Е - изменить характеристики моделя. Q - отменить действие.");
                
                while (true)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.E)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Q)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Неправильный ввод.");
                    }
                }
                
                
            }
            Console.WriteLine("Введите параметры экрана [пример: 6.53\", 2340x1080 (19.5:9)]: ");
            var screen = Console.ReadLine();
           
            Console.WriteLine("Введите параметры камеры [пример: 4 модуля, fullHD 60 к/с, видео 4K]: ");
            var camera = Console.ReadLine();
            
            Console.WriteLine("Введите параметры памяти [пример: 64 ГБ, слот для карты microSD]: ");
            var memory = Console.ReadLine();

            Console.WriteLine("Введите параметры hardware [пример: 8 ядер(а), 2 ГГц, оперативка 6 ГБ]: ");
            var hardware = Console.ReadLine();

            Console.WriteLine("Введите параметры аккумулятора [пример: 4500 мАч]: ");
            var battery = Console.ReadLine();

            
            var characteristiscks = new Characteristic(screen, camera, memory, hardware, battery);
            var characteristick_ctrl = new CharactersController(model.Name);
            characteristick_ctrl.Add(characteristiscks);
            Console.WriteLine("Новый смартфон добавлен. Нажмите Enter кнопку чтобы продолжить.");
            Console.ReadLine();
        }

        private static void PrintDevice(PhonesController phones_ctrl)
        {
            Console.Clear();
            Console.WriteLine("Выберите название и нажмите Enter:");
            for (int i = 0; i < phones_ctrl.Phones.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {phones_ctrl.Phones[i]}");
            }
            while (true)
            {
                if(int.TryParse(Console.ReadLine(),out int numPhone)&&numPhone <= phones_ctrl.Phones.Count)
                {
                    var phoneName = phones_ctrl.Phones[numPhone - 1].Name;
                    Console.WriteLine($"Вы выбрали: {phoneName}");
                    phones_ctrl.AddnSetCurrent(phoneName);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            
            
            var models_controller = new ModelsController(phones_ctrl.current_phone);

            if (models_controller.Models.Count == 0)
            {
                Console.WriteLine($"У {phones_ctrl.current_phone.Name} не найдено моделей. Нажмите любую кнопку чтобы продолжить.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Выберите модель и нажмите Enter.");
            //models_controller.RemoveModel(2);
            for(int i = 0; i < models_controller.Models.Count; i++)
            {
                Console.WriteLine($"{i+1} - {models_controller.Models[i]}");
            }
            string modelName;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(),out int numModel) && numModel <= models_controller.Models.Count)
                {
                    modelName = models_controller.Models[numModel-1].Name;
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            
           
            var characteristicksCtrl = new CharactersController(modelName);
            var Characteristick = characteristicksCtrl.Characteristic;
            Console.WriteLine($"Экран: {Characteristick.Screen}");
            Console.WriteLine($"Камера: {Characteristick.Camera}");
            Console.WriteLine($"Память: {Characteristick.Memory}");
            Console.WriteLine($"Hardware: {Characteristick.Hardware}");
            Console.WriteLine($"Аккумулятор: {Characteristick.Battery}");
            Console.WriteLine("Нажмите Enter кнопку чтобы продолжить.");
            Console.ReadLine();
        }
    }
}
