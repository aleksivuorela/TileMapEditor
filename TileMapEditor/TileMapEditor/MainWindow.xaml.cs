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
        private Map map;

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
                map = new Map(askDimsWindow.Rows, askDimsWindow.Columns, askDimsWindow.TileWidth, askDimsWindow.TileHeight);
                this.DataContext = map;
                SetImages(map.cropTileSet());
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
            //TODO
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void lvTileSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO
        }

        private void SetImages(List<CroppedBitmap> images)
        {
            try
            {
                lvTileSet.Items.Clear();
                foreach (var image in images)
                {
                    lvTileSet.Items.Add(new Image() { Source = image });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
