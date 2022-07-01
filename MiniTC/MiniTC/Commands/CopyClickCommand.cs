using MiniTC.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniTC.Commands
{
    public class CopyClickCommand : MainViewModel
    {       
        private ICommand _copyClick = null;
        public ICommand CopyClick
        {
            get
            {
                if (_copyClick == null)
                {
                    //MessageBox.Show(File.Exists(Left.SelectedItem).ToString());
                    //MessageBox.Show(Directory.Exists(Right.Path).ToString());
                    _copyClick = new RelayCommand(
                        copyFile, arg => true
                        //arg => File.Exists(Left.Path) && Directory.Exists(Right.Path)
                        );
                }
                return _copyClick;
            }
        }

        private ICommand _leftItemChanged = null;
        public ICommand LeftItemChanged                             //przy zmianie elementu w listbox na folder/plik update listy
        {
            get
            {
                if (_leftItemChanged == null)
                {
                    _leftItemChanged = new RelayCommand(Left.Update, arg => true);
                }
                return _leftItemChanged;
            }
        }
        private ICommand _rightItemChanged = null;
        public ICommand RightItemChanged
        {
            get
            {
                if (_rightItemChanged == null)
                {
                    _rightItemChanged = new RelayCommand(Right.Update, arg => true);
                }
                return _rightItemChanged;
            }
        }
        private ICommand _leftDriveChanged = null;
        public ICommand LeftDriveChanged                            //przy zmianie dysku odpalamy domyslna sciezke
        {
            get
            {
                if (_leftDriveChanged == null)
                {
                    _leftDriveChanged = new RelayCommand(Left.SetDefaultPath, arg => true);
                }
                return _leftDriveChanged;
            }
        }
        private ICommand _rightDriveChanged = null;

        public CopyClickCommand()
        {
        }

        public CopyClickCommand(ICommand copyClick, ICommand leftItemChanged, ICommand rightItemChanged, ICommand leftDriveChanged, ICommand rightDriveChanged)
        {
            _copyClick = copyClick;
            _leftItemChanged = leftItemChanged;
            _rightItemChanged = rightItemChanged;
            _leftDriveChanged = leftDriveChanged;
            _rightDriveChanged = rightDriveChanged;
        }

        public ICommand RightDriveChanged
        {
            get
            {
                if (_rightDriveChanged == null)
                {
                    _rightDriveChanged = new RelayCommand(Right.SetDefaultPath, arg => true);
                }
                return _rightDriveChanged;
            }
        }
    }
}
