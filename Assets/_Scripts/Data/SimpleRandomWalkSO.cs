using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRandomWalkData")]
public class SimpleRandomWalkSO : ScriptableObject
{
    public int _iterations = 10, _walkLength = 10;
    public bool _startRandomlyEachIteration = true;
}
