using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CosmoStatePattern.BadEx.UI
{
    /// <summary>
    /// Interaction logic for EntryPage.xaml
    /// </summary>
    public partial class EntryPage : Page
    {
        public EntryPage()
        {
            InitializeComponent();
        }
        private void ValidateNumber(Object sender, TextCompositionEventArgs e)
        {
            Regex regX = new Regex("[^0-9]");
            e.Handled = regX.IsMatch(e.Text);
        }
    }
}
