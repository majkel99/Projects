using MiniTC.Commands;
using MiniTC.ViewModel.Bases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public UserControlTC Left { get; set; }
        public UserControlTC Right { get; set; }
        public MainViewModel()                                      //main vm, tworzymy left right kontrolki
        {
            Left = new UserControlTC();
            Right = new UserControlTC();
        }
        public void copyFile(object sender)
        {
            string dest = Right.Path;                               //tam gdzie chcemy przeniesc
            string temp = dest;
            dest += "\\" + new DirectoryInfo(Left.Path).Name;
            try
            {
                if (File.Exists(Right.Path))
                {
                    Right.RefreshPath(Directory.GetParent(temp).ToString());
                    return;
                }
                if (!File.Exists(dest) && File.Exists(Left.Path))
                {
                    File.Copy(Left.Path, dest);
                    Right.RefreshPath(temp);                        //refresh bo inaczej nie wyswietla od razu
                }
            }
            catch (UnauthorizedAccessException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
