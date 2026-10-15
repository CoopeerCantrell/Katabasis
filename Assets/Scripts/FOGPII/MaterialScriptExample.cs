using UnityEngine;

public class MaterialScriptExample : MonoBehaviour
{
    public float speed = 0.0f;
    private Renderer renderer;
    private Material material;
    public bool arrowTrue = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Speed", speed);
        speed++;
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("button was hit");
            if (arrowTrue == false)
            {
                Debug.Log("arrowtrue false");
                SetArrowTrue();
            }
            if (arrowTrue)
            {
                Debug.Log("arrowtrue true");
                SetArrowFalse();
            }
        }
    }

    public void SetArrowTrue()
    {
        material.SetFloat("_Arrow_1", 1f);
        arrowTrue = true;
    }

    public void SetArrowFalse()
    {
        material.SetFloat("_Arrow_1", 0f);
        arrowTrue = false;
    }
}
