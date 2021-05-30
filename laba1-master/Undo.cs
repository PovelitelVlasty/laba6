using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace laba1
{
    public class Undo
    {
        public List<Shape> un = new List<Shape>();
        private List<Shape> re = new List<Shape>();

        public void add(Shape currSh) {
            re.Clear();
            un.Add(currSh);
        }
        public void redraw(Graphics g) {
            g.Clear(Color.White);
            for (int i = 0; i < un.Count; i++) {
                un[i].Draw(g);
            }
        }
        public void ctrlZ(Graphics g)
        {
            if (un.Count != 0)
            {
                re.Add(un[un.Count-1]);
                un.RemoveAt(un.Count-1);
                redraw(g);
            }
        }
        public void serialise() {
            var saveFileAs = new SaveFileDialog();
            saveFileAs.Filter = @"File json (*.json)|*.json";
            saveFileAs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileAs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileAs.FileName;

                try
                {
                    var currShape = un;

                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
                    serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                    serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

                    using (StreamWriter sw = new StreamWriter(filename))
                    using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, currShape);
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
        }
        public void deserialise()
        {
            re.Clear();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = @"File json (*.json)|*.json";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var filename = openFileDialog.FileName;
                    var currShape = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Shape>>(File.ReadAllText(filename), new Newtonsoft.Json.JsonSerializerSettings
                    {
                        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    });
                    un = currShape;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            
        }
        public void restart() {
            un.Clear();
            re.Clear();
        }
        public void ctrlY(Graphics g) 
        {
            if (re.Count != 0)
            {
                un.Add(re[re.Count - 1]);
                re.RemoveAt(re.Count - 1);
                redraw(g);
            }
        }
    }
}
