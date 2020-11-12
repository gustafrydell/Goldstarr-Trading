using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Newtonsoft.Json;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class FileManager
    {
        private string _fileName { get; set; }

        public FileManager(string fileName)
        {
            _fileName = fileName;
        }
        public async void SaveFile<T>(T collection)
        {
            string jsonCollection;

            jsonCollection = JsonConvert.SerializeObject(collection, Newtonsoft.Json.Formatting.None);

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile jsonfile;
            try
            {
                jsonfile = await storageFolder.GetFileAsync(_fileName);
            }
            catch (FileNotFoundException)
            {
                jsonfile = await storageFolder.CreateFileAsync(_fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await Windows.Storage.FileIO.WriteTextAsync(jsonfile, jsonCollection, Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }

        public async Task<T> ReadFromFile<T>()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file;
            try
            {
                file = await storageFolder.GetFileAsync(_fileName);
            }
            catch (FileNotFoundException)
            {
                file = await storageFolder.CreateFileAsync(_fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var text = await Windows.Storage.FileIO.ReadTextAsync(file);
            T obj = JsonConvert.DeserializeObject<T>(text);

            return obj;
        }
    }
}

