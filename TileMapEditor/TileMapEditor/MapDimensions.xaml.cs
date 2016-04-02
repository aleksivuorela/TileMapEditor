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
        private string _tileSetPath;
        private int _tileSetMargin;

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

        public string TileSetPath
        {
            get { return _tileSetPath; }
            set { _tileSetPath = value; }
        }

        public int TileSetMargin
        {
            get { return _tileSetMargin; }
            set { _tileSetMargin = value; }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rows = int.Parse(txtMapHeight.Text);
                int columns = int.Parse(txtMapWidth.Text);
                int tileWidth = int.Parse(txtTileWidth.Text);
                int tileHeight = int.Parse(txtTileHeight.Text);
                string tileSetPath = txtFileName.Text;
                int tileSetMargin = int.Parse(txtTileSetMargin.Text);

                if (rows > 0 && columns > 0 && tileWidth > 0 && tileHeight > 0 && tileSetMargin >= 0)
                {
                    _rows = rows;
                    _columns = columns;
                    _tileWidth = tileWidth;
                    _tileHeight = tileHeight;
                    _tileSetPath = tileSetPath;
                    _tileSetMargin = tileSetMargin;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Täytä kentät oikein.");
                }            
            }
            catch (Exception)
            {
                MessageBox.Show("Täytä kentät oikein.");
            }          
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                txtFileName.Text = filename;
            }
        }
    }
}
