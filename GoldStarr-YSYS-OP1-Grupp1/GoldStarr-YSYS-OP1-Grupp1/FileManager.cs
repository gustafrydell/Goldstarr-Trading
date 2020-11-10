using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class FileManager
    {
        public class ObjectToSave
        {
            public ObservableCollection<Customer> CustomerCollection { get; set; }
        }

        public static async void SaveToFile()
        {
            ObjectToSave objectToSave = new ObjectToSave() { CustomerCollection = CustomerViewList.Customers };
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Customers.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(ObjectToSave));
            if (file != null)
            {
                using (var mstream = new MemoryStream())
                {
                    var sw = new StreamWriter(mstream, new UTF8Encoding(false));
                    using (sw)
                    {
                        serializer.Serialize(sw, objectToSave);
                        mstream.Position = 0;
                        using (var sr = new StreamReader(mstream))
                        {
                            var t = sr.ReadToEnd();
                            await Windows.Storage.FileIO.WriteTextAsync(file, t, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                        }
                    }
                }
            }
            else
            {
                CreateFile();
            }
        }
        public static async void ReadFromFile()
        {
            ObjectToSave fileToRead;
            try
            {
                StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Customers.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectToSave));

                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    fileToRead = (ObjectToSave)serializer.Deserialize(stream);
                }
                CustomerViewList.Customers = fileToRead.CustomerCollection;
            }
            catch (FileNotFoundException)
            {
                CreateFile();
            }
        }
        public static async void CreateFile()
        {
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("Customers.xml", CreationCollisionOption.ReplaceExisting);
        }
    }
}

