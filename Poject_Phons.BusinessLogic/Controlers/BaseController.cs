using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Poject_Phons.BusinessLogic.Controlers
{
    public abstract class BaseController
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using(var filestream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if(filestream.Length>0&&formatter.Deserialize(filestream)is T item)
                {
                    return item;
                }
                else
                {
                    return default(T);  
                }
            }
        }
    }
}
