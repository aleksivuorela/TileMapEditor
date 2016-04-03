using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor
{
    public class Map
    {
        private int _mapRows;
        private int _mapColumns;
        private List<Tile> _mapTiles;

        public Map(int rows, int columns, int tileWidth, int tileHeight)
        {
            _mapRows = rows;
            _mapColumns = columns;
            _mapTiles = new List<Tile>(); 
            setEmptyTiles(tileWidth, tileHeight);        
        }

        public int MapRows
        {
            get { return _mapRows; }
            set { _mapRows = value; }
        }

        public int MapColumns
        {
            get { return _mapColumns; }
            set { _mapColumns = value; }
        }

        public List<Tile> MapTiles
        {
            get { return _mapTiles; }
        }    

        private void setEmptyTiles(int tileWidth, int tileHeight)
        {
            for (int r = 0; r < _mapRows; r++)
            {
                for (int c = 0; c < _mapColumns; c++)
                {
                    Tile tile = new Tile(tileWidth, tileHeight);
                    _mapTiles.Add(tile);
                }
            }
        } 
  
    }
}