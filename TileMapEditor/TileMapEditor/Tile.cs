using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TileMapEditor
{
    public class Tile
    {
        private string _imagePath;

        public Tile()
        {
        }

        public Tile(string imagePath)
        {
            _imagePath = imagePath;
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }
    }
}
