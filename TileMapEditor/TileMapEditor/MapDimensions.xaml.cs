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
        private int _tileWidth;
        private int _tileHeight;

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

        public int TileWidth
        {
            get { return _tileWidth; }
            set { _tileWidth = value; }
        }

        public int TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //Tarkista etteivät ole tyhjiä kenttiä!
            _rows = int.Parse(txtMapHeight.Text);
            _columns = int.Parse(txtMapWidth.Text);
            _tileWidth = int.Parse(txtTileWidth.Text);
            _tileHeight = int.Parse(txtTileHeight.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
