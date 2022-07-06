using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelView : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tileMapGround;

    [SerializeField]
    private Tile _tileGround;

    [SerializeField]
    private int _widthMap;

    [SerializeField]
    private int _heightMap;

    [SerializeField]
    private int _factorSmooth;

    [SerializeField] [Range(0,100)]
    private int _randomFillPresent;

    public Tilemap TileMapGround  => _tileMapGround; 
    public Tile TileGround  => _tileGround; 
    public int WidthMap  => _widthMap; 
    public int HeightMap => _heightMap;
    public int FactorSmooth  => _factorSmooth; 
    public int RandomFillPresent  => _randomFillPresent; 
}
