using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TileMapEditor
{
    public class Tile
    {
        private BitmapSource _tileSetBitmap;
        private Int32Rect _renderRect;
        private CroppedBitmap _tileSprite;

        public Tile(int tileWidth, int tileHeight)
        {
            int stride = tileWidth / 8;
            byte[] pixels = new byte[tileHeight * stride];

            List<Color> colors = new List<Color>();
            Color color = Color.FromArgb(50, 192, 192, 192);
            colors.Add(color);
            BitmapPalette myPalette = new BitmapPalette(colors);

            BitmapSource empty = BitmapSource.Create(
                tileWidth,
                tileHeight,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);

            _tileSetBitmap = empty;
            _renderRect = new Int32Rect();
            _tileSprite = new CroppedBitmap(_tileSetBitmap, _renderRect);
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

        public void setData(BitmapSource tileSetBitmap, Int32Rect renderRect)
        {
            _tileSetBitmap = tileSetBitmap;
            _renderRect = renderRect;
            _tileSprite = new CroppedBitmap(_tileSetBitmap, _renderRect);
        }

        public BitmapSource TileSetBitmap
        {
            get { return _tileSetBitmap; }
        }

        public Int32Rect RenderRect
        {
            get { return _renderRect; }
        }
    }
}
