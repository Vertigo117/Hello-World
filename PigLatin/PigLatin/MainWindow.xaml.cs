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

namespace PigLatin
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

        private void InputTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox[] textBoxes = new TextBox[] { inputTextBox, outputTextBox };

            foreach (TextBox t in textBoxes)
            {
                t.Text = "";
            }

            outputTextBox.Background = Brushes.LightGray;
            startButton.Click += new RoutedEventHandler(button_Click);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            outputTextBox.Text = (TranslateToPigLatin(inputTextBox.Text, letterTextBox.Text));
        }

        private string TranslateToPigLatin(string s, string letter)
        {
            LinkedList<char> charList = new LinkedList<char>();
            char constConsonant = Convert.ToChar(letter);

            foreach (char c in s)
            {
                charList.AddLast(c);
            }

            LinkedListNode<char> node;

            for(node=charList.Last;node!=null;node=node.Previous)
            {
                if(IsVowel(node.Value))
                {
                    charList.AddAfter(node, LowerLiteral(node.Value));
                    charList.AddAfter(node, constConsonant);
                }
            }

            s = "";

            foreach(char c in charList)
            {
                s += c;
            }

            return s;
        }

        private bool IsVowel(char c)
        {
            bool result = "аеёиоуыэюяАЕЁИОУЫЭЮЯ".IndexOf(c) >= 0;
            return result;
        }

        private char LowerLiteral(char c)
        {
            string s = c.ToString();
            s = s.ToLower();
            c =Convert.ToChar(s);

            return c;
        }
    }
}
