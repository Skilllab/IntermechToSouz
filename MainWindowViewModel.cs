using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using Newtonsoft.Json;
using Streamdivision.Framework;

namespace IntermechToSouz
{
    public class MainWindowViewModel : CoreNotifyModel
    {
        private ObservableCollection<PLMTree> _plmTree;
        private string pathToSourceFile;

        public MainWindowViewModel()
        {
            PlmTree = new ObservableCollection<PLMTree>();
        }

        public ICommand Build => new RelayCommand(onBuild);

        public ObservableCollection<PLMTree> PlmTree
        {
            get => _plmTree;
            set
            {
                _plmTree = value;
                OnPropertyChanged();
            }
        }

        public ICommand Save => new RelayCommand(onSave);


        private void BuildTree(PLMTree tree, AppModel assembly, List<AppModel> models)
        {
            var childrens = models.Where(r => r.Parent == assembly.Designation).ToList();

            foreach (var appModel in childrens)
            {
                var child = new PLMTree(appModel);
                tree.AddChild(child);
                if (appModel.ModelType == ModelType.Assembly)
                {
                    BuildTree(child, appModel, models);
                }
            }
        }

        private bool GetFile(out string path)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                return true;
            }

            path = null;
            return false;
        }

        private void onBuild()
        {
            if (!GetFile(out var path))
            {
                return;
            }

            pathToSourceFile = path;
            var ser = new XmlSerializer(typeof(Intermech));
            Intermech cars;
            using (var reader = XmlReader.Create(path))
            {
                cars = (Intermech) ser.Deserialize(reader);
            }

            //Берём только сборки, детали и стандартные
            var rer = (
                from c in cars.ListOfForms
                from a1 in c.Formattribute
                where (a1.Name == "Код типа объекта") & (a1.Value == "4" || a1.Value == "3" || a1.Value == "1")
                select c).ToList();

            var Models = new List<AppModel>();
            foreach (var form in rer)
            {
                Models.Add(new AppModel(form.Formattribute));
            }

            var firstLevel = Models.FirstOrDefault(r => r.Parent.NullOrEmptyOrWhiteSpace());
            if (firstLevel != null)
            {
                var fir = new PLMTree(firstLevel);
                BuildTree(fir, firstLevel, Models);
                PlmTree.Add(fir);
            }
        }

        private void onSave()
        {
            if (PlmTree.Count < 1)
            {
                return;
            }


            var dir = Path.GetDirectoryName(pathToSourceFile);

            var newPath = Path.Combine(dir, "Пример выгрузки дерева.json");


            File.WriteAllText(newPath,
                JsonConvert.SerializeObject(PlmTree[0],
                    new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
        }
    }
}