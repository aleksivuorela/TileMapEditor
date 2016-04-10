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
        private string filename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /* Kysytään käyttäjältä mapin ja tilesetin tiedot uudessa ikkunassa, joiden pohjalta luodaan mappi ja tileset niiden konstruktoreilla */
                /* Jos ikkunan arvot tyhjiä -> käyttäjä painoi cancelia eli ei tehdä mitään */
                MapDimensions askDimsWindow = new MapDimensions();
                askDimsWindow.ShowDialog();
                if (askDimsWindow.Rows != 0 && askDimsWindow.Columns != 0 && askDimsWindow.TileWidth != 0 && askDimsWindow.TileHeight != 0)
                {
                    _map = new Map(askDimsWindow.Rows, askDimsWindow.Columns, askDimsWindow.TileWidth, askDimsWindow.TileHeight);
                    _tileSet = new TileSet(askDimsWindow.TileSetPath, askDimsWindow.TileWidth, askDimsWindow.TileHeight, askDimsWindow.TileSetMargin);
                    updateUI();
                    filename = null;
                    this.Title = "Untitled - TileMapEditor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            /* Avataan olemassa oleva mappi tiedostosta, mappi ja tileset luodaan toisella konstruktorilla */
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".tmap";
            dlg.Filter = "TileMap files (.tmap)|*.tmap";
            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                try
                {
                    _tileSet = new TileSet(filename);
                    _map = new Map(filename, _tileSet);
                    updateUI();
                    this.Title = filename + " - TileMapEditor";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }            
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            /* Jos tiedoston nimi on jo tiedossa, tallennetaan suoraan sen päälle. Muuten käytetään saveAs:ia eli kysytään käyttäjältä minne/millä nimellä tallennetaan */
            if (filename == null)
                saveAs();
            else
                _map.saveMap(filename, _tileSet.TileSetPath, _tileSet.Margin);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            saveAs();
        }

        private void lvTileSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedTileFromSet = (Tile)lvTileSet.SelectedItem;
        }

        private void lvMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* Jos jokin tiili on valittu sekä tilesetistä että mapista, asetetaan mapista valitun tiilen tiedot samoiksi mitkä valitulla tilesetin tiilellä */
            if (_selectedTileFromSet != null && lvMap.SelectedItems.Count > 0)
            {
                Tile selectedTileFromMap = (Tile)lvMap.SelectedItem;
                selectedTileFromMap.setData(_selectedTileFromSet.TileSetBitmap, _selectedTileFromSet.RenderRect, _selectedTileFromSet.TileNumber);
            }
        }

        private void updateUI()
        {
            gridLeft.Visibility = Visibility.Visible;
            gridRight.Visibility = Visibility.Visible;     
            lvMap.DataContext = _map;
            lvTileSet.DataContext = _tileSet;
            menuSave.IsEnabled = true;
            menuSaveAs.IsEnabled = true;
        }

        private void saveAs()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".tmap";
            dlg.Filter = "TileMap files (.tmap)|*.tmap";
            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                this.Title = filename +  " - TileMapEditor";
                _map.saveMap(filename, _tileSet.TileSetPath, _tileSet.Margin);
            }
        }

    }
}
