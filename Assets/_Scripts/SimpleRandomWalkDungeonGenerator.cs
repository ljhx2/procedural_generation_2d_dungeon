using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField] SimpleRandomWalkSO _randomWalkParameters;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(_randomWalkParameters);
        _tilemapVisualizer.Clear();
        _tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, _tilemapVisualizer);
    }

    private HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters)
    {
        var currentPosition = _startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters._iterations; i++)
        {
            var path = ProceduralGenrationAlgorithms.SimpleRandomWalk(currentPosition, parameters._walkLength);
            floorPositions.UnionWith(path);
            if (parameters._startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }

}
