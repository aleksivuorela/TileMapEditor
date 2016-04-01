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
            try
            {
                int rows = int.Parse(txtMapHeight.Text);
                int columns = int.Parse(txtMapWidth.Text);
                int tileWidth = int.Parse(txtTileWidth.Text);
                int tileHeight = int.Parse(txtTileHeight.Text);

                if (rows > 0 && columns > 0 && tileWidth > 0 && tileHeight > 0)
                {
                    _rows = rows;
                    _columns = columns;
                    _tileWidth = tileWidth;
                    _tileHeight = tileHeight;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vain positiiviset kokonaisluvut kelpaavat.");
                }            
            }
            catch (Exception)
            {
                MessageBox.Show("Vain positiiviset kokonaisluvut kelpaavat.");
            }          
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
