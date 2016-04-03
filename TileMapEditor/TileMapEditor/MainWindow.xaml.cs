﻿using System;
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
        private List<Tile> _selectedTiles;

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
                    _map = new Map(askDimsWindow.Rows, askDimsWindow.Columns, askDimsWindow.TileWidth, askDimsWindow.TileHeight);
                    lvMap.DataContext = _map;
                    _tileSet = new TileSet(askDimsWindow.TileSetPath, askDimsWindow.TileWidth, askDimsWindow.TileHeight, askDimsWindow.TileSetMargin);
                    lvTileSet.DataContext = _tileSet;
                    _selectedTiles = new List<Tile>();
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
            //TODO
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void lvTileSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedTiles.Clear();
            foreach (Tile tile in lvTileSet.SelectedItems)
            {
                _selectedTiles.Add(tile);
            }
        }

        private void lvMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_selectedTiles.Count > 0)
            {
                foreach (Tile tile in lvMap.SelectedItems)
                {
                    for (int i = 0; i < _selectedTiles.Count(); i++)
                    { 
                        tile.setData(_selectedTiles[i].TileSetBitmap, _selectedTiles[i].RenderRect);
                        MessageBox.Show(_selectedTiles[i].TileSetBitmap.ToString() + "-------" + _selectedTiles[i].RenderRect.ToString());
                    }
                }
            }
        }
    }
}
