using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sharpads.IO
{
    public class FileMan
    {
        public DirectoryInfo configDir = new DirectoryInfo(Application.StartupPath);
        public FileInfo configFile
        {
            get
            {
                return new FileInfo(configDir.FullName + "/config.json");
            }
        }
        public static FileMan man;
        public FileMan()
        {
            man = this;
        }

        public void resetConfig()
        {
            if (configFile.Exists)
            {
                configFile.Delete();
            }
            if (configDir.Exists)
            {
                configDir.Delete();
            }
            saveConfig();
        }

        public void saveConfig()
        {
            //McmJson root = new McmJson();
            //string json = new JavaScriptSerializer().Serialize(root);
            //File.WriteAllText(configFile.Name, json);
            File.WriteAllText(configFile.Name, "");
        }

        //returns false if it fails
        public bool readConfig()
        {
            try
            {
                if (!configDir.Exists)
                {
                    configDir.Create();
                    return false;
                }
                if (!configFile.Exists)
                {
                    configFile.Create();
                    return false;
                }
                string json = File.ReadAllText(configFile.FullName);
                // McmJson root = new JavaScriptSerializer().Deserialize<McmJson>(json);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Data corrupt, repairing data.", "corrupt data.");
                resetConfig();
                return false;
            }
        }
    }
}
