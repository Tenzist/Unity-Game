using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 0.125f;
    public Vector3 offset;
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
