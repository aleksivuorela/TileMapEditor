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
using System.Windows.Shapes;

namespace TileMapEditor
{
    /// <summary>
    /// Interaction logic for MapDimensions.xaml
    /// </summary>
    public partial class MapDimensions : Window
    {
        private int _rows;
        private int _columns;

        public MapDimensions()
        {
            InitializeComponent();
        }

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            _rows = int.Parse(txtHeight.Text);
            _columns = int.Parse(txtWidth.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
