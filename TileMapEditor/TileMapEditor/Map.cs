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
        private TileSet _tileSet;
        private List<Tile> _tiles;

        public Map(int rows, int columns, string tileSetPath, int tileWidth, int tileHeight, int margin)
        {
            _rows = rows;
            _columns = columns;
            _tileSet = new TileSet(tileSetPath, tileWidth, tileHeight, margin);
            _tiles = _tileSet.Tiles;
            //setTiles();        
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

        public TileSet TileSet
        {
            get { return _tileSet; }
            set { _tileSet = value; }
        }
        /*
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
        */    
    }
}