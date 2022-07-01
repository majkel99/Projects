using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }
        #region Własnosci
        //rejestracje wlasnosci, do bindowania //text, dyski, wybrany dysk, itemy, wybrany item
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
                "Text", typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty DriveSourceProperty = DependencyProperty.Register(
            "DriveSource", typeof(string[]), typeof(PanelTC), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CurrentDriveSourceProperty = DependencyProperty.Register(
            "CurrentDriveSource", typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register(
            "ItemSource", typeof(ObservableCollection<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CurrentItemSourceProperty = DependencyProperty.Register(
            "CurrentItemSource", typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region Gettery i Settery
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public string[] DriveSource
        {
            get { return (string[])GetValue(DriveSourceProperty); }
            set { SetValue(DriveSourceProperty, value); }
        }
        public string CurrentDriveSource
        {
            get { return (string)GetValue(CurrentDriveSourceProperty); }
            set { SetValue(CurrentDriveSourceProperty, value); }
        }
        public ObservableCollection<string> ItemSource
        {
            get { return (ObservableCollection<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }
        public string CurrentItemSource
        {
            get { return (string)GetValue(CurrentItemSourceProperty); }
            set { SetValue(CurrentItemSourceProperty, value); }
        }
        #endregion

        #region Eventy
        //do bindowania
        public static readonly RoutedEvent DriveChangeEvent =                       //rejestracja zdarzenia zmiany dysku, do bindowania
            EventManager.RegisterRoutedEvent("OtherDriveSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler DriveChanged                               //zdarzenie zmiany dysku             // do event trigger w mainwindow
        {
            add { AddHandler(DriveChangeEvent, value); }
            remove { RemoveHandler(DriveChangeEvent, value); }
        }
        void RaiseDriveChanged(object sender, SelectionChangedEventArgs e)          //metoda wywolujaca zdarzenie       //do kontrolki w xaml
        {
            RoutedEventArgs args = new RoutedEventArgs(DriveChangeEvent);           //argument zdarzenia
            RaiseEvent(args);                                                       //wywolanie zdarzenia
        }



        public static readonly RoutedEvent CurrentItemChangeEvent =
            EventManager.RegisterRoutedEvent("OtherItemSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler ItemChanged
        {
            add { AddHandler(CurrentItemChangeEvent, value); }
            remove { RemoveHandler(CurrentItemChangeEvent, value); }
        }
        void RaiseItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CurrentItemChangeEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
