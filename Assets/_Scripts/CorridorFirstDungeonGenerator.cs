using System;
using System.Collections.Generic;
using UnityEngine;

public class CorridorFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
{
    [SerializeField] private int _corridorLength = 14, _corridorCount = 5;
    [SerializeField][Range(0.1f, 1f)] private float _roomPercent = 0.8f;
    [SerializeField] public SimpleRandomWalkSO _roomGenerationParameters;
    

    protected override void RunProceduralGeneration()
    {
        CorridorFirstGeneration();
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        CreateCorridors(floorPositions);

        _tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, _tilemapVisualizer);
    }

    private void CreateCorridors(HashSet<Vector2Int> floorPositions)
    {
        var currentPosition = _startPosition;

        for (int i = 0; i < _corridorCount; i++)
        {
            var corridor = ProceduralGenrationAlgorithms.RandomWalkCorridor(currentPosition, _corridorLength);
            currentPosition = corridor[corridor.Count - 1];
            floorPositions.UnionWith(corridor);
        }
    }
}

