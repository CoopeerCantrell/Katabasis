using UnityEngine;

public class OrpheusMusic : MonoBehaviour
{
    Collider2D[] hitColliders;
    public float radius = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayMusic();
        }
    }
    void PlayMusic(){
        hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach (var hitCollider in hitColliders) 
    {
            if (hitCollider.CompareTag("Enemy"))
            {
                GameObject enemy = hitCollider.gameObject;
                float speeds = enemy.GetComponent<BasicEnemy>().speed;
                speeds = speeds / 2;
                enemy.GetComponent<BasicEnemy>().SetSpeed(speeds);
        }
    }
    }
}
