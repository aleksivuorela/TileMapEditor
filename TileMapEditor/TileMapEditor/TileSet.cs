using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TileMapEditor
{
    public class TileSet
    {
        private BitmapSource _tileSetBitmap;
        private int _tileWidth;
        private int _tileHeight;
        private int _margin;
        private List<Tile> _tiles = new List<Tile>();  
        private int _tilesPerRow;

        public TileSet(string tileSetPath, int tileWidth, int tileHeight, int margin)
        {
            _tileSetBitmap = new BitmapImage(new Uri(tileSetPath));
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _margin = margin;
            _tilesPerRow = (_tileSetBitmap.PixelWidth - margin) / (_tileWidth + margin);
            createTiles();
        }

        public List<Tile> Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        public int TilesPerRow
        {
            get { return _tilesPerRow; }
            set { _tilesPerRow = value; }
        }

        private void createTiles()
        {
            _tiles.Clear();
            for (int y = 0 + _margin; y < _tileSetBitmap.PixelHeight - _margin; y = y + _tileHeight + _margin)
            {
                for (int x = 0 + _margin; x < _tileSetBitmap.PixelWidth - _margin; x = x + _tileWidth + _margin)
                {
                    try
                    {
                        Tile tile = new Tile(_tileSetBitmap, new Int32Rect(x, y, _tileWidth, _tileHeight));
                        _tiles.Add(tile);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
