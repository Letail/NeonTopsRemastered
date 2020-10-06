using UnityEngine;

public class EnemySphereGizmo : MonoBehaviour
{
    public Color color;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, transform.localScale.x);
    }
}
