using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor
{
    public class Map
    {
        private int _mapRows;
        private int _mapColumns;
        private int _tileWidth;
        private int _tileHeight;
        private List<Tile> _mapTiles;
        private Tile[,] _mapTileArr;

        public Map(int rows, int columns, int tileWidth, int tileHeight)
        {
            /* Konstruktori luo uuden, tyhjän mapin */
            _mapRows = rows;
            _mapColumns = columns;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _mapTiles = new List<Tile>();
            _mapTileArr = new Tile[rows, columns];
            setEmptyTiles(tileWidth, tileHeight);
        }

        public Map(string filename, TileSet tileSet)
        {
            /* Konstruktori luo tiedostosta vanhan mapin */
            try
            {
                _tileWidth = tileSet.TileWidth;
                _tileHeight = tileSet.TileHeight;
                loadMap(filename, tileSet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int MapRows
        {
            get { return _mapRows; }
        }

        public int MapColumns
        {
            get { return _mapColumns; }
        }

        public List<Tile> MapTiles
        {
            get { return _mapTiles; }
        }    

        private void setEmptyTiles(int tileWidth, int tileHeight)
        {
            /* Luo tyhjät tiilet */
            for (int r = 0; r < _mapRows; r++)
            {
                for (int c = 0; c < _mapColumns; c++)
                {
                    Tile tile = new Tile(tileWidth, tileHeight);
                    _mapTiles.Add(tile); // tätä listaa tarvitaan vain listviewiin bindaukseen, koska 2d arraytä ei pystynyt
                    _mapTileArr[r, c] = tile; // 2d arraytä tarvitaan kaikkeen laskentaan
                }
            }
        } 

        public void saveMap(string filename, string tileSetPath, int margin)
        {
            /* Kirjoittaa mapin tiedostoon */
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"{tileSetPath},{_tileWidth},{_tileHeight},{margin}"); // ekalle riville tilesetin tiedot
                for (int r = 0; r < _mapRows; r++)
                {
                    for (int c = 0; c < _mapColumns; c++)
                    {
                        writer.Write(_mapTileArr[r,c].TileNumber);
                        if (c < _mapColumns - 1)
                            writer.Write(","); // kirjoitetaan tiilten numerot pilkulla eroteltuna
                    }
                    if (r < _mapRows - 1)
                        writer.WriteLine(); // rivinvaihto
                }
            }           
        }

        public void loadMap(string filename, TileSet tileSet)
        {
            /* Lataa mapin tiedostosta */
            try
            {
                string[] lines = File.ReadAllLines(filename);
                _mapRows = lines.Length - 1;
                _mapColumns = lines[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                _mapTiles = new List<Tile>();
                _mapTileArr = new Tile[_mapRows, _mapColumns];

                using (StreamReader reader = new StreamReader(filename))
                {
                    reader.ReadLine(); // skipataan eka rivi
                    int r = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine(); // luetaan tiedosto rivi kerrallaan
                        var values = line.Split(','); // tallennetaan rivin pilkulla erotellut tiilten numerot taulukon paikkoihin

                        for (int c = 0; c < values.Length; c++) // käydään taulukko läpi
                        {
                            Tile setTile = tileSet.getTileByNumber(int.Parse(values[c])); // haetaan tilesetistä numeroa vastaava tiili
                            Tile mapTile = new Tile(setTile.TileSetBitmap, setTile.RenderRect, setTile.TileNumber); // luodaan uusi tiili mappiin haetun tilesetin tiilen tiedoilla
                            _mapTiles.Add(mapTile);
                            _mapTileArr[r, c] = mapTile;
                        }
                        r++; // vaihdetaan riviä ja toistetaan kunnes tiedosto loppuu -> koko mappi luotu tiedostosta
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}