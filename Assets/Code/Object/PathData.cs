using UnityEngine;

[CreateAssetMenu(fileName = "PathData", menuName = "Scriptable Objects/PathData")]
public class PathData : ScriptableObject
{
    public bool useLocalSpace = true;
    public Vector3[] points;
}
