using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TileMapEditor
{
    public class TileSet
    {
        private string _tileSetPath;
        private BitmapSource _bitmap;
        private int _tileWidth;
        private int _tileHeight;
        private int _margin;
        private List<Tile> _tiles;
        private int _columns;
        private int _tileNumber;

        public TileSet(string tileSetPath, int tileWidth, int tileHeight, int margin)
        {
            _tileSetPath = tileSetPath;
            _bitmap = new BitmapImage(new Uri(tileSetPath));
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _margin = margin;
            _tiles = new List<Tile>();
            _columns = (_bitmap.PixelWidth - margin) / (_tileWidth + margin);
            createTiles();
        }

        public TileSet(string filename)
        {
            try
            {
                loadTileSet(filename);
                _bitmap = new BitmapImage(new Uri(_tileSetPath));
                _tiles = new List<Tile>();
                _columns = (_bitmap.PixelWidth - _margin) / (_tileWidth + _margin);
                createTiles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string TileSetPath
        {
            get { return _tileSetPath; }
        }

        public int TileWidth
        {
            get { return _tileWidth; }
        }

        public int TileHeight
        {
            get { return _tileHeight; }
        }

        public int Margin
        {
            get { return _margin; }
        }

        public List<Tile> TileSetTiles
        {
            get { return _tiles; }
        }

        public int TileSetColumns
        {
            get { return _columns; }
        }

        public Tile getTileByNumber(int number)
        {
            try
            {
                Tile tile;
                if (number == -1)
                    tile = new Tile(_tileWidth, _tileHeight);
                else
                    tile = _tiles.Single(t => t.TileNumber == number); //Single will return a single result, but will throw an exception if it finds none or more than one
                return tile;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void createTiles()
        {
            _tiles.Clear();
            _tileNumber = -1;
            for (int y = 0 + _margin; y < _bitmap.PixelHeight - _margin; y = y + _tileHeight + _margin)
            {
                for (int x = 0 + _margin; x < _bitmap.PixelWidth - _margin; x = x + _tileWidth + _margin)
                {
                    try
                    {
                        _tileNumber++;
                        Tile tile = new Tile(_bitmap, new Int32Rect(x, y, _tileWidth, _tileHeight), _tileNumber);
                        _tiles.Add(tile);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void loadTileSet(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    var line = reader.ReadLine(); //ekalta riviltä luetaan tilesetin tiedot
                    var values = line.Split(','); //rivin järjestys: tileSetPath, tileWidth, tileHeight, margin
                    _tileSetPath = values[0];
                    _tileWidth = int.Parse(values[1]);
                    _tileHeight = int.Parse(values[2]);
                    _margin = int.Parse(values[3]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
