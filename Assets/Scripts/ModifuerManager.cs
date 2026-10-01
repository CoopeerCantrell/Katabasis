using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModifuerManager : MonoBehaviour
{
     public static ModifuerManager Instance;

    public static ModifuerManager GetInstance()
    {
        return Instance;
    }
    [Header("choice 1")]
    public GameObject modifierPanel;
    public Image portrait1;
    public TMP_Text nameText1;
    public TextMeshProUGUI textComponent1;
    public GameObject button1;

    [Header("choice 2")]
    public Image portrait2;
    public TMP_Text nameText2;
    public TextMeshProUGUI textComponent2;
    public GameObject button2;

    [Header("modifiers")]
    public static int speedStack = 0;
    public static int fallSpeedStack = 0;
    public static int musicRadiusStack = 0;


    public void Awake()
    {
        if (ModifuerManager.Instance != this && ModifuerManager.Instance != null)
        {
            Destroy(ModifuerManager.Instance);
            Instance = this;
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
