using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor
{
    public class Map
    {
        private int _rows;
        private int _columns;
        private List<Tile> _tiles = new List<Tile>();

        public Map(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    _tiles.Add(new Tile("d:\\img.png")); //korjaa OpenFileDialogiksi!
                }
            }
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
    }
}
