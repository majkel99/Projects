﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMplusDazy.ViewModel
{
    using Model;
    using Databases.Encje;
    using Databases.Repozytoria;
    using System.Collections.ObjectModel;
    using System.Windows;

    class MainVM : BaseVM
    {
        #region Atrybuty
        private ObservableCollection<string> _listOfProductsInShop;
        private ObservableCollection<Product> _buyProducts;
        private ObservableCollection<Shop> _listOfShops;
        private List<User> _listOfUsers;
        //private User _owner = new User();
        #endregion

        #region GetSet
        public ObservableCollection<string> ListOfProductsInShop { get; set; }
        public ObservableCollection<Product> BuyProducts { get; set; }
        public ObservableCollection<Shop> ListOfShops { get; set; }
        public ObservableCollection<User> ListOfUsers { get; set; }
        #endregion

        #region VMy
        public StartWindowVM SW { get; set; } = new StartWindowVM();
        public RegisterWindowVM RW { get; set; } = new RegisterWindowVM();
        public LogOwnerVM LO { get; set; } = new LogOwnerVM();
        public LogUserVM LU { get; set; } = new LogUserVM();
        public MainModel MM { get; set; } = new MainModel();
        #endregion

        public MainVM()
        {
            RW.SWVM = SW;
            RW.MM = MM;

            SW.RWVM = RW;
            SW.LOVM = LO;
            SW.LUVM = LU;

            LO.SWVM = SW;
            LO.MVM = this;
            LO.MM = MM;

            LU.SWVM = SW;
            LU.RWVM = RW;
            LU.MVM = this;
            LU.MM = MM;
        }

        #region ICommandy StartControl
        private ICommand _registerUserClick = null;
        public ICommand RegisterUserClick
        {
            get
            {
                if (_registerUserClick == null)
                {
                    _registerUserClick = new RelayCommand(SW.Register, arg => true);
                }
                return _registerUserClick;
            }
        }
        private ICommand _loginUserClick = null;
        public ICommand LoginUserClick
        {
            get
            {
                if (_loginUserClick == null)
                {
                    _loginUserClick = new RelayCommand(SW.LoginUser, arg => true);
                }
                return _loginUserClick;
            }
        }
        private ICommand _loginOwnerClick = null;
        public ICommand LoginOwnerClick
        {
            get
            {
                if (_loginOwnerClick == null)
                {
                    _loginOwnerClick = new RelayCommand(SW.LoginOwner, arg => true);
                }
                return _loginOwnerClick;
            }
        }
        #endregion

        #region ICommandy RegisterControl
        private ICommand _goBackRegisterClick = null;
        public ICommand GoBackRegisterClick
        {
            get
            {
                if (_goBackRegisterClick == null)
                {
                    _goBackRegisterClick = new RelayCommand(RW.GoBackRegister, arg => true);
                }
                return _goBackRegisterClick;
            }
        }

        private ICommand _registerClick = null;
        public ICommand RegisterClick
        {
            get
            {
                if (_registerClick == null)
                {
                    _registerClick = new RelayCommand(RW.Register, arg => true);
                    
                }
                return _registerClick;
            }
        }
        #endregion

        #region ICommandy OwnerLoginControl
        private ICommand _logOwner = null;
        public ICommand LogOwner
        {
            get
            {
                if (_logOwner == null)
                {
                    _logOwner = new RelayCommand(LO.LogOwner, arg => true);
                }
                return _logOwner;
            }
        }
        private ICommand _goBackLogOwnerClick = null;
        public ICommand GoBackLogOwnerClick
        {
            get
            {
                if (_goBackLogOwnerClick == null)
                {
                    _goBackLogOwnerClick = new RelayCommand(LO.GoBackLogOwner, arg => true);
                }
                return _goBackLogOwnerClick;
            }
        }
        #endregion

        #region ICommandy UserLoginControl
        private ICommand _logUser = null;
        public ICommand LogUser
        {
            get
            {
                if (_logUser == null)
                {
                    _logUser = new RelayCommand(LU.LogUser, arg => true);
                }
                return _logUser;
            }
        }
        private ICommand _goBackLogUserClick = null;
        public ICommand GoBackLogUserClick
        {
            get
            {
                if (_goBackLogUserClick == null)
                {
                    _goBackLogUserClick = new RelayCommand(LU.GoBackLogUser, arg => true);
                }
                return _goBackLogUserClick;
            }
        }
        #endregion

        #region ICommandy GoShoppingControl
        private ICommand _addClick = null;
        public ICommand AddClick
        {
            get
            {
                if (_addClick == null)
                {
                    _addClick = new RelayCommand(LU.AddClick, arg => true);
                }
                return _addClick;
            }
        }
        private ICommand _infoClick = null;
        public ICommand InfoClick
        {
            get
            {
                if (_infoClick == null)
                {
                    _infoClick = new RelayCommand(LU.InfoClick, arg => true);
                }
                return _infoClick;
            }
        }
        private ICommand _delClick = null;
        public ICommand DelClick
        {
            get
            {
                if (_delClick == null)
                {
                    _delClick = new RelayCommand(LU.DelClick, arg => true);
                }
                return _delClick;
            }
        }
        private ICommand _buyClick = null;
        public ICommand BuyClick
        {
            get
            {
                if (_buyClick == null)
                {
                    _buyClick = new RelayCommand(LU.BuyClick, arg => true);
                }
                return _buyClick;
            }
        }       
        
        private ICommand _selectedProductChanged = null;
        public ICommand SelectedProductChanged
        {
            get
            {
                if (_selectedProductChanged == null)
                {
                    _selectedProductChanged = new RelayCommand(LU.LoadQuantity, arg => true);
                }
                return _selectedProductChanged;
            }
        }
        #endregion

        #region ICommandy GoToListControl
        private ICommand _loadTransaction = null;
        public ICommand LoadTransaction
        {
            get
            {
                if (_loadTransaction == null)
                {
                    _loadTransaction = new RelayCommand(LU.LoadTransactionInfo, arg => true);
                }
                return _loadTransaction;
            }
        }
        
        #endregion

        #region ICommandy EditUserControl
        
        private ICommand _editClick = null;
        public ICommand EditClick
        {
            get
            {
                if (_editClick == null)
                {
                    _editClick = new RelayCommand(LU.EditClick, arg => true);
                }
                return _editClick;
            }
        }
        #endregion

        #region ICommandy AddToMagazineControl
        private ICommand _addToMagazineClick = null;
        public ICommand AddToMagazineClick
        {
            get
            {
                if (_addToMagazineClick == null)
                {
                    _addToMagazineClick = new RelayCommand(LO.AddToMagazineClick, arg => true);
                }
                return _addToMagazineClick;
            }
        }
        private ICommand _selectedShopChanged = null;
        public ICommand SelectedShopChanged
        {
            get
            {
                if (_selectedShopChanged == null)
                {
                    _selectedShopChanged = new RelayCommand(LO.ChangeShop, arg => true);
                }
                return _selectedShopChanged;
            }
        }
        private ICommand _selectedProductAndQuantityChanged = null;
        public ICommand SelectedProductAndQuantityChanged
        {
            get
            {
                if (_selectedProductAndQuantityChanged == null)
                {
                    _selectedProductAndQuantityChanged = new RelayCommand(LO.ChangeItem, arg => true);
                }
                return _selectedProductAndQuantityChanged;
            }
        }

        #endregion

        #region ICommandy OwnerClickControl
        private ICommand _goToMagazClickOwner = null;
        public ICommand GoToMagazClickOwner
        {
            get
            {
                if (_goToMagazClickOwner == null)
                {
                    _goToMagazClickOwner = new RelayCommand(LO.GoToMagazineClick, arg => true);
                }
                return _goToMagazClickOwner;
            }
        }
        private ICommand _goToAddItemClickOwner = null;
        public ICommand GoToAddItemClickOwner
        {
            get
            {
                if (_goToAddItemClickOwner == null)
                {
                    _goToAddItemClickOwner = new RelayCommand(LO.GoToAddItemClick, arg => true);
                }
                return _goToAddItemClickOwner;
            }
        }
        private ICommand _goToListCLickOwner = null;
        public ICommand GoToListClickOwner
        {
            get
            {
                if (_goToListCLickOwner == null)
                {
                    _goToListCLickOwner = new RelayCommand(LO.GoToListClick, arg => true);
                }
                return _goToListCLickOwner;
            }
        }
        private ICommand _goToDelItemCLickOwner = null;
        public ICommand GoToDelItemClickOwner
        {
            get
            {
                if (_goToDelItemCLickOwner == null)
                {
                    _goToDelItemCLickOwner = new RelayCommand(LO.GoToDelItemClick, arg => true);
                }
                return _goToDelItemCLickOwner;
            }
        }
        private ICommand _goToDelShopCLickOwner = null;
        public ICommand GoToDelShopClickOwner
        {
            get
            {
                if (_goToDelShopCLickOwner == null)
                {
                    _goToDelShopCLickOwner = new RelayCommand(LO.GoToDelShopClick, arg => true);
                }
                return _goToDelShopCLickOwner;
            }
        }
        private ICommand _goToAddShopCLickOwner = null;
        public ICommand GoToAddShopClickOwner
        {
            get
            {
                if (_goToAddShopCLickOwner == null)
                {
                    _goToAddShopCLickOwner = new RelayCommand(LO.GoToAddShopClick, arg => true);
                }
                return _goToAddShopCLickOwner;
            }
        }
        #endregion

        #region ICommandy UserClickControl
        private ICommand _goToEditClickUser = null;
        public ICommand GoToEditClickUser
        {
            get
            {
                if (_goToEditClickUser == null)
                {
                    _goToEditClickUser = new RelayCommand(LU.GoToEditClick, arg => true);
                }
                return _goToEditClickUser;
            }
        }
        private ICommand _goToListClickUser = null;
        public ICommand GoToListClickUser
        {
            get
            {
                if (_goToListClickUser == null)
                {
                    _goToListClickUser = new RelayCommand(LU.GoToList, arg => true);
                }
                return _goToListClickUser;
            }
        }
        private ICommand _goToShoppingClickUser = null;
        public ICommand GoToShoppingClickUser
        {
            get
            {
                if (_goToShoppingClickUser == null)
                {
                    _goToShoppingClickUser = new RelayCommand(LU.GoToShopping, arg => true);
                }
                return _goToShoppingClickUser;
            }
        }
        #endregion

        #region ICommandy ListOwnerControl
        private ICommand _loadOrdersOfUser = null;
        public ICommand LoadOrdersOfUser
        {
            get
            {
                if (_loadOrdersOfUser == null)
                {
                    _loadOrdersOfUser = new RelayCommand(LO.LoadOrdersOfUser, arg => true);
                }
                return _loadOrdersOfUser;
            }
        }
        private ICommand _loadOrderDetails = null;
        public ICommand LoadOrderDetails
        {
            get
            {
                if (_loadOrderDetails == null)
                {
                    _loadOrderDetails = new RelayCommand(LO.LoadOrderDetails, arg => true);
                }
                return _loadOrderDetails;
            }
        }
        #endregion 

        #region ICommandy AddItemOwnerControl
        private ICommand _addItemClickOwner = null;
        public ICommand AddItemClickOwner
        {
            get
            {
                if (_addItemClickOwner == null)
                {
                    _addItemClickOwner = new RelayCommand(LO.AddItemClick, arg => true);
                }
                return _addItemClickOwner;
            }
        }
        #endregion

        #region ICommandy DelItemOwnerControl
        private ICommand _itemToDelChanged = null;
        public ICommand ItemToDelChanged
        {
            get
            {
                if (_itemToDelChanged == null)
                {
                    _itemToDelChanged = new RelayCommand(LO.ItemToDelChanged, arg => true);
                }
                return _itemToDelChanged;
            }
        }
        private ICommand _delItemClick = null;
        public ICommand DelItemClick
        {
            get
            {
                if (_delItemClick == null)
                {
                    _delItemClick = new RelayCommand(LO.DelItemClick, arg => true);
                }
                return _delItemClick;
            }
        }
        private ICommand _restockItemClick = null;
        public ICommand RestockItemClick
        {
            get
            {
                if (_restockItemClick == null)
                {
                    _restockItemClick = new RelayCommand(LO.RestockItemClick, arg => true);
                }
                return _restockItemClick;
            }
        }
        #endregion

        #region ICommandy AddShopOwnerControl
        private ICommand _addShopClick = null;
        public ICommand AddShopClick
        {
            get
            {
                if (_addShopClick == null)
                {
                    _addShopClick = new RelayCommand(LO.AddShopClick, arg => true);
                }
                return _addShopClick;
            }
        }
        #endregion

        #region ICommandy DelShopOwnerControl
        private ICommand _delShopClick = null;
        public ICommand DelShopClick
        {
            get
            {
                if (_delShopClick == null)
                {
                    _delShopClick = new RelayCommand(LO.DelShopClickOwner, arg => true);
                }
                return _delShopClick;
            }
        }
        private ICommand _delShopChanged = null;
        public ICommand DelShopChanged
        {
            get
            {
                if (_delShopChanged == null)
                {
                    _delShopChanged = new RelayCommand(LO.DelShopChanged, arg => true); ;
                }
                return _delShopChanged;
            }
        }
        #endregion
    }

}
