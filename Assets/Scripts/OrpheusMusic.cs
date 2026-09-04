using System.Collections;
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
            StartCoroutine(RunFunctionForFiveSeconds());
        }
    }
    void PlayMusic(){
    
    hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach (var hitCollider in hitColliders) 
    {
            if (hitCollider.CompareTag("Enemy"))
            {
                GameObject enemy = hitCollider.gameObject;
                float orispeeds = enemy.GetComponent<BasicEnemy>().speed;
                if(orispeeds != 0){
                    orispeeds = -10;
                }
                
                enemy.GetComponent<BasicEnemy>().SetSpeed(orispeeds);
                Debug.Log("set original speed");
                float speeds = orispeeds /4;
                enemy.GetComponent<BasicEnemy>().SetSpeed(speeds);
                Debug.Log("set slower speed");
        }
    }
    }

    void ResetSpeed(){
        hitColliders = Physics2D.OverlapCircleAll(transform.position,radius + 2);
        foreach (var hitCollider in hitColliders) 
    {
            if (hitCollider.CompareTag("Enemy"))
            {
                GameObject enemy = hitCollider.gameObject;
                float orispeeds = enemy.GetComponent<BasicEnemy>().speed;
                if(orispeeds != 0)
                    orispeeds = -10;
                enemy.GetComponent<BasicEnemy>().SetSpeed(orispeeds);
                Debug.Log("set original speed after leaving area of ability");
        }
    }
    }

    IEnumerator RunFunctionForFiveSeconds()
    {
        float elapsedTime = 0f;
        float duration = 5f;

        while (elapsedTime < duration)
        {
            ResetSpeed();
            PlayMusic();
            
            elapsedTime += Time.deltaTime; 
            yield return null; 
        }
        
        ResetSpeed();
        Debug.Log("5 seconds are up! Stopped calling the function.");
    }
}
