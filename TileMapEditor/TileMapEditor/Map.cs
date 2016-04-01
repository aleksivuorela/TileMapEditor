using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TileMapEditor
{
    public class Map
    {
        private int _rows;
        private int _columns;
        private int _tileWidth;
        private int _tileHeight;
        private List<Tile> _tiles = new List<Tile>();
        private BitmapSource _tileSet = new BitmapImage(new Uri("d://tileset.png"));
        private List<CroppedBitmap> _tileSetCropped = new List<CroppedBitmap>();
        private int margin = 1; //korjaa!
        private int _tilesPerRow;

        public Map(int rows, int columns, int tileWidth, int tileHeight)
        {
            _rows = rows;
            _columns = columns;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _tilesPerRow = (_tileSet.PixelWidth - margin) / (_tileWidth + margin);
            setTiles();        
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

        private void setTiles()
        {
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _columns; c++)
                {
                    _tiles.Add(new Tile());
                }
            }
        }

        public List<CroppedBitmap> cropTileSet()
        {   
            _tileSetCropped.Clear();
            for (int y = 0 + margin ; y < _tileSet.PixelHeight - margin; y = y + _tileHeight + margin)
            {
                for (int x = 0 + margin; x < _tileSet.PixelWidth - margin; x = x + _tileWidth + margin)
                {
                    try
                    {
                        CroppedBitmap cb = new CroppedBitmap(_tileSet, new Int32Rect(x, y, _tileWidth, _tileHeight));
                        _tileSetCropped.Add(cb);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return _tileSetCropped;
        }
    }
}