using System;
using System.Windows;

namespace DecimalToBCD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // чтение введенного значения
            if (int.TryParse(DecimalInput.Text, out int decimalNumber) && decimalNumber > 0 && decimalNumber < 255)
            {
                // преобразование в двоично-десятичный код (BCD 8421)
                string bcd = DecimalToBCD(decimalNumber);
                BCDOutput.Text = bcd;
            }
            else
            {
                MessageBox.Show("Введите десятичное число от 1 до 254.");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // функция для преобразования десятичного числа в BCD 8421
        private string DecimalToBCD(int number)
        {
            string bcd = "";
            foreach (char digit in number.ToString())
            {
                int decimalDigit = int.Parse(digit.ToString());
                string binaryString = Convert.ToString(decimalDigit, 2).PadLeft(4, '0');
                bcd += binaryString + " ";
            }
            return bcd.Trim();
        }
    }
}
