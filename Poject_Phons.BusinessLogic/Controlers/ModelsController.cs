using Poject_Phons.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Poject_Phons.BusinessLogic.Controlers
{
    public class ModelsController:BaseController
    {
        public List<Model> Models { get; }
        
        public Phone Phone { get; }
        public bool newModel { get; private set; } = false;

        
        public ModelsController (Phone phone)
        {
            Phone = phone ?? throw new ArgumentNullException("Смартфон не може быть null", nameof(phone));
            Models = GetModels();
           
        }

        public void RemoveModel(int index)
        {
            Models.RemoveAt(index);
            Save();
        }

        public void Add(Model model)
        {
            var _model = Models.SingleOrDefault(x => x.Name == model.Name);
            if (_model == null)
            {
                Models.Add(model); 
                newModel = true;
            }

            Save();
        }

        private void Save()
        {
            Save(Phone.Name,Models);
        }

        private List<Model> GetModels()
        {
            return Load<List<Model>>(Phone.Name) ?? new List<Model>();
        }
    }
}
