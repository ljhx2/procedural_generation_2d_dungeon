using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap _floorTilemap, _wallTilemap;
    [SerializeField] private TileBase _floorTile, _wallTop;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTIles(floorPositions, _floorTilemap, _floorTile);
    }

    private void PaintTIles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (Vector2Int position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }
    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(_wallTilemap, _wallTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        _floorTilemap.ClearAllTiles();
        _wallTilemap.ClearAllTiles();
    }

    
}
