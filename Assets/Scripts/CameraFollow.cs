using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lockedX = 0f;
    public float cameraLevel = 8;
    public bool canFollow = false;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lockedX = gameObject.transform.position.x;
    }
    void LateUpdate()
    {
        if (target != null && canFollow)
        {

            transform.position = new Vector3(lockedX, target.position.y - cameraLevel, -10);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canFollow = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //canFollow = false;
        }
    }
}
