using System.Collections;
using UnityEngine;

public class OrpheusMusic : MonoBehaviour
{
    Collider2D[] hitColliders;
    public float radius = 1f;
    public float radiusModifier = 1f;
    public bool musicCooldown = false;
    public GameObject musicAura;
    public bool radIncreased = false;
    public float maxTimer = 5f;
    public float timerModifier = 0f;
    public bool noMusic = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && musicCooldown != true && noMusic != true)
        {
            StartCoroutine(RunFunctionForFiveSeconds());
        }
        if (radIncreased)
        {
            musicAura.transform.localScale += Vector3.one * radiusModifier;
            radIncreased = false;
        }
    }
    void PlayMusic()
    {

        hitColliders = Physics2D.OverlapCircleAll(transform.position, (radius + radiusModifier));
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                GameObject enemy = hitCollider.gameObject;
                float orispeeds = enemy.GetComponent<BasicEnemy>().speed;
                float speeds = orispeeds / 4;
                Debug.Log(speeds);
                enemy.GetComponent<BasicEnemy>().SetSpeed(speeds);
                Debug.Log("set slower speed");
            }
        }
    }

    void ResetSpeed()
    {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, (radius + radiusModifier) + 2);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                GameObject enemy = hitCollider.gameObject;
                float orispeeds = enemy.GetComponent<BasicEnemy>().oriSpeed;
                enemy.GetComponent<BasicEnemy>().SetSpeed(orispeeds);
                Debug.Log("set original speed after leaving area of ability");
            }
        }
    }

    IEnumerator RunFunctionForFiveSeconds()
    {
        musicAura.SetActive(true);
        PlayMusic();
        yield return new WaitForSeconds(maxTimer + timerModifier);
        //ResetSpeed();
        musicAura.SetActive(false);
        StartCoroutine(CoolDownFor3Sec());
        Debug.Log("5 seconds are up! Stopped calling the function.");
    }
    IEnumerator CoolDownFor3Sec()
    {
        musicCooldown = true;
        yield return new WaitForSeconds(1);
        musicCooldown = false;
    }
}
