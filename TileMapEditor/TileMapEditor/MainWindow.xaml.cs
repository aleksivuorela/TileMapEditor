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

namespace TileMapEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Map _map;
        private TileSet _tileSet;
        private Tile _selectedTileFromSet;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MapDimensions askDimsWindow = new MapDimensions();
                askDimsWindow.ShowDialog();
                if (askDimsWindow.Rows != 0 && askDimsWindow.Columns != 0 && askDimsWindow.TileWidth != 0 && askDimsWindow.TileHeight != 0)
                {
                    gridLeft.Visibility = Visibility.Visible;
                    gridRight.Visibility = Visibility.Visible;
                    _map = new Map(askDimsWindow.Rows, askDimsWindow.Columns, askDimsWindow.TileWidth, askDimsWindow.TileHeight);
                    lvMap.DataContext = _map;
                    _tileSet = new TileSet(askDimsWindow.TileSetPath, askDimsWindow.TileWidth, askDimsWindow.TileHeight, askDimsWindow.TileSetMargin);
                    lvTileSet.DataContext = _tileSet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;
                _map.saveMap(filename);
            }          
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void lvTileSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedTileFromSet = (Tile)lvTileSet.SelectedItem;
        }

        private void lvMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_selectedTileFromSet != null && lvMap.SelectedItems.Count > 0)
            {
                Tile selectedTileFromMap = (Tile)lvMap.SelectedItem;
                selectedTileFromMap.setData(_selectedTileFromSet.TileSetBitmap, _selectedTileFromSet.RenderRect, _selectedTileFromSet.TileNumber);
            }
        }
    }
}
