using MiniTC.ViewModel.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.ViewModel
{
    public class UserControlTC : ViewModelBase
    {
        private string _path;
        private string _currentDrive;
        private string _currentItem;
        private ObservableCollection<string> _items;

        public UserControlTC()
        {
            DriveList = Directory.GetLogicalDrives();
            CurrentDrive = DriveList[0];
            Path = CurrentDrive;
            Items = Load(CurrentDrive);
        }


        #region Getters & Setters
        public string Path
        {
            get => _path;
            set { _path = value; OnPropertyChanged(nameof(Path)); }
        }

        public string[] DriveList { get; set; }
        public string CurrentDrive { get => _currentDrive; set { _currentDrive = value; OnPropertyChanged(nameof(CurrentDrive)); } }

        public ObservableCollection<string> Items { get => _items; set { _items = value; OnPropertyChanged(nameof(Items)); } }

        public string CurrentItem { get => _currentItem; set { _currentItem = value; OnPropertyChanged(nameof(CurrentItem)); } }

        #endregion

        public ObservableCollection<string> Load(string arg_path)
        {
            try
            {
                ObservableCollection<string> elements = new ObservableCollection<string>();
                string[] dir = Directory.GetDirectories(arg_path);
                string[] files = Directory.GetFiles(arg_path);
                string fullPath = string.Empty;                         //zmienne na foldery, pliki i sciezke, zeby sobie wracac i isc dalej
                if (!DriveList.Contains(arg_path))                     //jesli lista jeszcze niczego nie zawiera i jest to cos innego niz default dysk, to załaduj kropki
                {
                    elements.Add("...");
                }
                for (int i = 0; i < dir.Length; i++)
                {
                    //elements.Add("<" + arg_path[0] + ">" + new DirectoryInfo(dir[i]).Name);
                    elements.Add("<D>" + new DirectoryInfo(dir[i]).Name);
                }
                for (int i = 0; i < files.Length; i++)
                {
                    elements.Add(new DirectoryInfo(files[i]).Name);
                }
                return elements;
            }
            catch (UnauthorizedAccessException)
            {
                //MessageBox.Show(ex.Message);
                SetDefaultPath(new object());
                return Items;
            }
        }

        public void SetDefaultPath(object sender)
        {
            Path = CurrentDrive;
            Items = Load(CurrentDrive);
        }
        public void RefreshPath(string arg_path)
        {
            Path = arg_path;
            Items = Load(arg_path);
        }
        public void Update(object sender)
        {
            FileAttributes att = File.GetAttributes(Path);
            DirectoryInfo parent_dir = Directory.GetParent(Path);       //pobieramy info o tym co jest wyzej
            string fullPath = string.Empty;                             //cala sciezka, do doklejania
            if (fullPath == string.Empty)
            {
                fullPath += Path;                                       //doklejamy aktualna sciezke
                if (File.Exists(fullPath))                              //jak plik, to cala sciezka to to co jest wyzej
                {
                    fullPath = parent_dir.FullName;
                }
            }
            if (CurrentItem != null)
            {
                if (CurrentItem == "...")                               //jezeli 3 kropki, tj jezeli chcemy isc wyzej
                {                                                       //pobieramy info o tym co wyzej i reload listy
                    if (att.HasFlag(FileAttributes.Directory))          //klikamy od lapy na kropki
                    {
                        Path = parent_dir.FullName;
                        Items = Load(Path);
                    }
                    else                                                //klikamy majac wybrany/aktywny jakis element
                    {
                        parent_dir = Directory.GetParent(parent_dir.FullName);
                        Path = parent_dir.FullName;
                        Items = Load(Path);
                    }
                    CurrentItem = null;
                }
                else if (CurrentItem[0] == '<')                        //jezeli idziemy do folderu (nazwy folderu zaczynaja sie od <)
                {
                    if (fullPath != (Path[0] + ":\\"))
                    {
                        CurrentItem = CurrentItem.Substring(3);
                        fullPath += "\\" + CurrentItem;
                    }
                    else                                                //pierwszy folder od dysku, to nie musimy doklejac slasha, bo domyslnie jest
                    {
                        CurrentItem = CurrentItem.Substring(3);
                        fullPath += CurrentItem;
                    }
                    Path = fullPath;                                    //sciezka po doklejeniu slasha i elementu i reload
                    Items = Load(fullPath);
                }
                else                                                    //jesli plik
                {
                    if (fullPath != (Path[0] + ":\\"))
                    {
                        fullPath += "\\" + CurrentItem;
                    }
                    else                                                //pierwszy plik od dysku, to nie musimy doklejac slasha, bo domyslnie jest
                    {
                        fullPath += CurrentItem;
                    }
                    Path = fullPath;
                }
            }
        }
    }
}

