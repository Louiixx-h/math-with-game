using UnityEngine;

public class Cartesian : MonoBehaviour
{
    public int yRange;
    public int xRange;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Vector2.zero, Vector2.up * yRange);
        Gizmos.DrawLine(Vector2.zero, Vector2.up * yRange * -1);
        Gizmos.DrawLine(Vector2.zero, Vector2.right * xRange);
        Gizmos.DrawLine(Vector2.zero, Vector2.right * xRange * -1);
    }
}
