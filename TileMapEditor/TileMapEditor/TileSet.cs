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
        private BitmapSource _tileSet;
        private int _tileWidth;
        private int _tileHeight;
        private int _margin;
        private List<CroppedBitmap> _tileSetCropped = new List<CroppedBitmap>();  
        private int _tilesPerRow;

        public TileSet(string tileSetPath, int tileWidth, int tileHeight, int margin)
        {
            _tileSet = new BitmapImage(new Uri(tileSetPath));
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _margin = margin;
            _tilesPerRow = (_tileSet.PixelWidth - margin) / (_tileWidth + margin);
        }

        public int TilesPerRow
        {
            get { return _tilesPerRow; }
            set { _tilesPerRow = value; }
        }

        public List<CroppedBitmap> cropTileSet()
        {
            _tileSetCropped.Clear();
            for (int y = 0 + _margin; y < _tileSet.PixelHeight - _margin; y = y + _tileHeight + _margin)
            {
                for (int x = 0 + _margin; x < _tileSet.PixelWidth - _margin; x = x + _tileWidth + _margin)
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
