using System;
using System.Collections;
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

    public GenerateLevelController(GenerateLevelView view)
    {
        _tileMapGround = view.TileMapGround;
        _tileGround = view.TileGround;
        _widthMap = view.WidthMap;
        _heightMap = view.HeightMap;
        _factorSmooth = view.FactorSmooth;
        _randomFillPresent = view.RandomFillPresent;

        _map = new int[_widthMap, _heightMap];
    }

    public void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        RandomFillLevel();
    }

    private void RandomFillLevel()
    {
        var psevdoRandom = new System.Random(); 

    }
}
