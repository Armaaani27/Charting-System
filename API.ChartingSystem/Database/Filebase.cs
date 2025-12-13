using Library.ChartingSystem.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace API.ChartingSystem.Database
{
    public class Filebase
    {
        private string _root;
        private string _physicianRoot;
        private static Filebase _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ChartingSystemData");

            _physicianRoot = Path.Combine(_root, "physicians");

            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }

            if (!Directory.Exists(_physicianRoot))
            {
                Directory.CreateDirectory(_physicianRoot);
            }
        }

        public int LastPhysicianKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        public Physician AddOrUpdate(Physician physician)
        {
            //set up a new Id if one doesn't already exist
            if(physician.Id <= 0)
            {
                physician.Id = LastPhysicianKey + 1;
            }

            //go to the right place
            string filename = $"{physician.Id}.json";
            string path = Path.Combine(_physicianRoot, filename);
            

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(physician));

            //return the item, which now has an id
            return physician;
        }
        
        public List<Physician> Physicians
        {
            get
            {
                var root = new DirectoryInfo(_physicianRoot);
                var _physicians = new List<Physician>();
                foreach(var physicianFile in root.GetFiles())
                {
                    try
                    {
                        string content = File.ReadAllText(physicianFile.FullName);
                        if (string.IsNullOrWhiteSpace(content))
                            continue;

                        var physician = JsonConvert.DeserializeObject<Physician>(content);
                        if (physician != null)
                        {
                            _physicians.Add(physician);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }

                }
                return _physicians;
            }
        }


        public bool Delete(int id)
        {
            string path = Path.Combine(_physicianRoot, $"{id}.json");

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }


   
}