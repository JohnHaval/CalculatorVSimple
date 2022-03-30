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

namespace CalculatorVSimple
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text.Length != 0) Result.Text = Result.Text.Remove(Result.Text.Length - 1, 1);
        }

        private void Multiple_Click(object sender, RoutedEventArgs e)
        {
            if(Prover()) Result.Text = Result.Text.Insert(Result.Text.Length, "x");            
        }
        private bool Prover()
        {
            if (Result.Text.IndexOf("+") == -1 && Result.Text.IndexOf("-") == -1 && Result.Text.IndexOf("/") == -1 && Result.Text.IndexOf("x") == -1 && Result.Text.Length != 0) return true;
            return false;
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "1";
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "2";
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "3";
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "4";
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "5";
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "6";
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "7";
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "8";
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "9";
        }

        private void _0_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "0";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (Prover()) Result.Text = Result.Text.Insert(Result.Text.Length, "-");
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Prover()) Result.Text = Result.Text.Insert(Result.Text.Length, "+");
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (Prover()) Result.Text = Result.Text.Insert(Result.Text.Length, "/");
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text.IndexOf(".") == -1 || Result.Text.IndexOf(".", Result.Text.IndexOf(".")) == -1) Result.Text += ".";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus) Plus_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D1) _1_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D2) _2_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D3) _3_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D4) _4_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D5) _5_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D6) _6_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D7) _7_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D8) _8_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D9) _9_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.D0) _0_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.OemMinus) Minus_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.X) Multiple_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.Divide) Divide_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.Back) Backspace_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.C) Clear_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.Enter) Equal_Click(sender, new RoutedEventArgs());
            if (e.Key == Key.Subtract) Point_Click(sender, new RoutedEventArgs());
        }

        private void Equal_Click(object sender, RoutedEventArgs e)//Выделить при помощи диапазона значений необходимые цифры(или фиксировать после нажатия действия)
        {
            try
            {
                int i;
                string action = "";
                for (i = 0; i < Result.Text.Length; i++)
                {

                    if (Result.Text[i].ToString() == "+" || Result.Text[i].ToString() == "-" ||
                        Result.Text[i].ToString() == "/" || Result.Text[i].ToString() == "x")
                    {
                        action = Result.Text[i].ToString(); 
                        break;
                    }
                }
                double a = Convert.ToDouble(Result.Text.Substring(0, i));                
                double b = Convert.ToDouble(Result.Text.Remove(0, i));
                if (action == "+")
                {
                    Result.Text = (a + b).ToString();
                }
                if (action == "-")
                {
                    Result.Text = (a - b).ToString();
                }
                if (action == "/")
                {
                    Result.Text = (a / b).ToString();
                }
                if (action == "x")
                {
                    Result.Text = (a * b).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка, введите действия заново", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
