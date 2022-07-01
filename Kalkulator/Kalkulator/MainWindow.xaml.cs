using System;
using System.Collections.Generic;
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
namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string operation;
        bool OperandPressed;
        
        private double showNumber;
        public double ShowNumber
        {
            get { return showNumber; }
            set
            {
                showNumber = value;
                txtDisplay.Text = ShowNumber.ToString(); 
            }
        }
        private double number1;
        public double Number1
        {
            get { return number1; }
            set { number1 = value; }
        }
        public double Number2 { get; set; }
        public double result { get; set; }
        public bool IsSecond { get; set; }
        public bool IsDecimal { get; set; }
        public int DecimalValue { get; set; }

        public string wynik { get; set; }



        public MainWindow()
        {
            InitializeComponent();
            ClearAll();
        }
        public void ClearAll()
        {
            ShowNumber = 0;
            result = 0;
            Number1 = 0;
            Number2 = 0;
            IsSecond = false;
            IsDecimal = false;
            DecimalValue = 1;
            operation = string.Empty;

        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            if(((txtDisplay.Text.ToString()=="0")) || (OperandPressed))
            {
                txtDisplay.Text = " ";
            }
            if (B.Content.ToString() == ",")
            {
                IsDecimal = true;
            }
            else
            {
                if (IsSecond)
                {
                    if (IsDecimal)
                    {
                        DecimalValue *= 10;
                        Number2 += double.Parse(B.Content.ToString()) / DecimalValue;
                    }
                    else
                    {
                        Number2 *= 10;
                        Number2 += double.Parse(B.Content.ToString());
                    }
                    ShowNumber = Number2;
                }
                else
                {
                    if (IsDecimal)
                    {
                        DecimalValue *= 10;
                        Number1 += double.Parse(B.Content.ToString()) / DecimalValue;
                    }
                    else
                    {
                        Number1 *= 10;
                        Number1 += double.Parse(B.Content.ToString());
                    }
                    ShowNumber = Number1;
                }
            }

            OperandPressed = false;
        }
        private void Button_Operation(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            if (operation == "")
            {
                operation = B.Content.ToString(); // store operand
                IsSecond = true;
                ShowNumber = Number2;
                IsDecimal = false;
                DecimalValue = 1;
            }
            else
            {
                Calculation();
                operation = B.Content.ToString();
            }
        }
        private void ButEquals_Click(object sender, RoutedEventArgs e)
        {
            Calculation();
            operation = "";    
        }
        private void Calculation()
        {
            if (operation == "+"){
                result = Number1 + Number2;
                ResetAfterCalculation();
            }
            else if (operation == "-")
            {
                result = Number1 - Number2;
                ResetAfterCalculation();
            }
            else if (operation == "X")
            {
                result = Number1 * Number2;
                ResetAfterCalculation();
            }
            else if (operation == "x^2")
            {
                result = Number1 * Number1;
                ResetAfterCalculation();
            }
            else if (operation == "1/x")
            {
                if (number1 == 0)
                {
                    MessageBox.Show("Nie dziel przez 0!");
                }
                else
                {
                    result = 1 / Number1;
                    ResetAfterCalculation();
                }
                
            }
            else if (operation == "/")
            {
                if(Number2 == 0)
                {
                    MessageBox.Show("Nie dziel przez 0!");
                }
                else
                {
                    result = (Number1 / Number2);
                    ResetAfterCalculation();
                }
                
            }

        }
        public void ResetAfterCalculation()
        {
            Number1 = result;
            ShowNumber = result;
            Number2 = 0;
        }
        private void ButClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }
        private void ButUNDO_Click(object sender, RoutedEventArgs e)
        {
               
        }
        private void ButPosNeg_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                Number1 *= -1;
                txtDisplay.Text = Number1.ToString();
            }
            else
            {
                Number2 *= -1;
                txtDisplay.Text = Number2.ToString();
            }
        }
    }
}
