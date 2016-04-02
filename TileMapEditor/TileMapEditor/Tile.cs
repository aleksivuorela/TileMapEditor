using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TileMapEditor
{
    public class Tile
    {
        private BitmapSource _tileSetBitmap;
        private Int32Rect _renderRect;
        private CroppedBitmap _tileSprite;

        public Tile()
        {
        }

        public Tile(BitmapSource tileSetBitmap, Int32Rect renderRect)
        {
            _tileSetBitmap = tileSetBitmap;
            _renderRect = renderRect;
            _tileSprite = new CroppedBitmap(_tileSetBitmap, _renderRect);
        }

        public CroppedBitmap TileSprite
        {
            get { return _tileSprite; }
            set { _tileSprite = value; }
        }
    }
}
