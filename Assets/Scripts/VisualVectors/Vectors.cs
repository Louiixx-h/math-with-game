using UnityEngine;

public class Vectors : MonoBehaviour
{
    public Vector2 u = new(1, 1);
    public Vector2 v = new(0, 1);

    void Update()
    {
        float y = Mathf.Sin(Time.time);
        float x = Mathf.Cos(Time.time);
        v.y = y;
        v.x = x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector2.zero, v.normalized);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector2.zero, u.normalized);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(u.normalized, v.normalized);
    }
}
