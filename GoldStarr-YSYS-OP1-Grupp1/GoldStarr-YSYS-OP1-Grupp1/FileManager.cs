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
            public ObservableCollection<Merchandise> MerchandiseCollection { get; set; }
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
                CreateFile(1);
            }

            ObjectToSave objectToSave2 = new ObjectToSave() { MerchandiseCollection = App._merchandiseManager.merchlist };
            StorageFile merchFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Merchandise.xml");

            if (merchFile != null)
            {
                using (var mstream = new MemoryStream())
                {
                    var sw = new StreamWriter(mstream, new UTF8Encoding(false));
                    using (sw)
                    {
                        serializer.Serialize(sw, objectToSave2);
                        mstream.Position = 0;
                        using (var sr = new StreamReader(mstream))
                        {
                            var t = sr.ReadToEnd();
                            await Windows.Storage.FileIO.WriteTextAsync(merchFile, t, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                        }
                    }
                }
            }
            else
            {
                CreateFile(2);
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
                CreateFile(1);
            }


            ObjectToSave fileToRead2;
            try
            {
                StorageFile file2 = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Merchandise.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectToSave));

                using (Stream stream = await file2.OpenStreamForReadAsync())
                {
                    fileToRead2 = (ObjectToSave)serializer.Deserialize(stream);
                }
                App._merchandiseManager.merchlist = fileToRead2.MerchandiseCollection;
            }
            catch (FileNotFoundException)
            {
                CreateFile(2);
            }


        }
        public static async void CreateFile(int b)
        {

            switch (b)
            {
                case 1:
                    StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("Customers.xml", CreationCollisionOption.ReplaceExisting);
                    break;
                case 2:
                    StorageFile file2 = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("Merchandise.xml", CreationCollisionOption.ReplaceExisting);
                    break;
            }

        }
    }
}

