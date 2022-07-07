using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelController
{
    private const int CountWall = 4;

    private Tilemap _tileMapGround;

    private Tile _tileGround;

    private int _widthMap;

    private int _heightMap;

    private int _factorSmooth;

    private int _randomFillPresent;

    private int[,] _map;

    private List<Tile> _tyleTypes;

    private int _numberTileTypes;


    public GenerateLevelController(GenerateLevelView view)
    {
        _tileMapGround = view.TileMapGround;
        _tileGround = view.TileGround;
        _widthMap = view.WidthMap;
        _heightMap = view.HeightMap;
        _factorSmooth = view.FactorSmooth;
        _randomFillPresent = view.RandomFillPresent;
        _tyleTypes = view.TileTypes;
        _numberTileTypes = _tyleTypes.Count;

        _map = new int[_widthMap, _heightMap];
    }

    public void Awake()
    {
       GenerateLevel();
    }

    public void ClearTileMap()
    {
        if( _tileMapGround != null )
            _tileMapGround.ClearAllTiles();
    }

    private void GenerateLevel()
    {
        for (int j = 0; j < _numberTileTypes; j++)
        {
            RandomFillLevel();

            for (var i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }

            DrawTilesOnMap(j);
        }
    }



    private void RandomFillLevel()
    {
        var psevdoRandom = new System.Random();

        for (var x = 0; x < _widthMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                if (x == 0 || x == _widthMap - 1 || y == 0 || y == _heightMap - 1)
                    _map[x, y] = 1;
                else
                    _map[x, y] = (psevdoRandom.Next(0, 100) < _randomFillPresent) ? 1 : 0;
            }
        }

    }

    private void SmoothMap()
    {
        for (var x = 0; x < _widthMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var neighbourWallTiles = GetSurroundingWallCount(x, y);
                if (neighbourWallTiles > CountWall)
                    _map[x, y] = 1;
                else if (neighbourWallTiles < CountWall)
                    _map[x, y] = 0;
            }
        }
    }

    private int GetSurroundingWallCount(int gridX, int gridY)
    {
        var wallCount = 0;

        for (var neighbourX = gridX - 1; neighbourX <= gridX +1 ; neighbourX++)
        {
            for (var neighbourY = gridY - 1; neighbourY <= gridY +1 ; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < _widthMap && neighbourY >= 0 && neighbourY < _heightMap)
                {
                    if (neighbourX !=gridX || neighbourY !=gridY)
                        wallCount += _map[neighbourX, neighbourY];
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }
         


    private void DrawTilesOnMap(int tile)
    {
        if (_map == null)
            return;

        for (var x = 0; x < _widthMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {

                if (_map[x, y] == 1)
                {
                    var positionTile = new Vector3Int(-_widthMap / 2 + x, -_heightMap / 2 + y, 0);
                    _tileMapGround.SetTile(positionTile, _tyleTypes[tile]);
                }
            }
        }
    }

}
