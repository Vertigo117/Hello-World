using System;
using System.Collections.Generic;
using System.Collections;
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

namespace Reverse_a_String
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

        private void InputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            revesedText.Text = ReverseString(inputText.Text);
        }

        private string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            s = "";
           
            for(int i =charArray.Length-1;i>=0;i--)
            {
                s += charArray[i];
            }

            return s;
        }
    }
}
