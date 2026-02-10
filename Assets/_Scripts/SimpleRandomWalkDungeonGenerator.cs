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
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        _tilemapVisualizer.Clear();
        _tilemapVisualizer.PaintFloorTiles(floorPositions);
    }

    private HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = _startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < _randomWalkParameters._iterations; i++)
        {
            var path = ProceduralGenrationAlgorithms.SimpleRandomWalk(currentPosition, _randomWalkParameters._walkLength);
            floorPositions.UnionWith(path);
            if (_randomWalkParameters._startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }

}
