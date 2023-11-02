using MaterialDesignColors.ColorManipulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace keyWPF
{
    public partial class MainWindow : Window
    {
        List<Button> buttonlist = new List<Button>();
        char[] chars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'q', 'w', 'e', 'r', 't', 'y',
            'u', 'i', 'o', 'p', '[', ']','\\', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';','z','x',
            'c','v','b','n','m',',','.','/' 
        };
        static int CountFails = 0;
        int pos = 0;
        char sign;
        public MainWindow()
        {
            InitializeComponent();
        }

        /*private void CreateButtons()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            for (int i = 0; i < chars.Count; i++)
            {
                var b = new Button() { Content = chars[i], Width = 50, Height = 50 };
                
                b.Style = (Style)FindResource("ButtonPressedStyle");
                stackPanel.Children.Add(b);
            }
            SPBase.Children.Add(stackPanel);
        }*/
        private void UpdateTextArea()
        {
            if (sign == tbText.Text.First())
            {
                StringBuilder stringBuilder = new StringBuilder(tbText.Text);
                stringBuilder.Remove(0, 1);
                tbText.Text = stringBuilder.ToString();
                tbText.UpdateLayout();
            }
            else
            {
                CountFails++;
                fails_lb.Content = CountFails.ToString();
            }
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
            this.Focus();
            string key = e.Key.ToString();
            if (key == "Space")
            {
                sign = ' ';
            }
            else
            {
                sign = char.ToLower(key[0]);
            }
            UpdateTextArea();
        }
    }

}