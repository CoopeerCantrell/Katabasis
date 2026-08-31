using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float lockedX = 0f; 
     

    void FixedUpdate()
    {
        if (target != null)
        {
            
            transform.position = new Vector3(lockedX, target.position.y, -10);
        }
    }
}
