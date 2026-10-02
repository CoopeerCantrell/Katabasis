using UnityEngine;

public class DialogInteraction : MonoBehaviour
{
         public bool InRange = false;



  

     public Dialogue text;

     public bool pauseGame = false;

     public bool once = false;

    public bool notAgain = false;

    

    public bool scriptedText;

    public bool canTalk = true;

    

    



    // Start is called before the first frame update
    void Start()
    {
        
        TextBoxManager.Instance.DiologueBox.SetActive(false);
        TextBoxManager.Instance.skip.SetActive(false);
        TextBoxManager.Instance.nameTextObj.SetActive(false);
        TextBoxManager.Instance.Objportrait.SetActive(false);
        
         
    }
 

    // Update is called once per frame
    void Update()
    {
        if(text.textActive == true)
        {
            canTalk = false;
        }
         if(InRange == true && canTalk == true)
            {
                if (Input.GetKeyDown(KeyCode.Space)&& text.textActive == false && scriptedText == false)
               {
                    
                    TextBoxManager.Instance.DiologueBox.SetActive(true);
                    TextBoxManager.Instance.Objportrait.SetActive(true);
                    TextBoxManager.Instance.skip.SetActive(true);
                    TextBoxManager.Instance.nameTextObj.SetActive(true);
                    
                    text.startDialogue();
                    

                }
            }
        if(text.textActive == false)
        {
            canTalk = true;
        }
        

        
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InRange = false;
        }
    }

    public void StartDiologue()
    {
        if(TextBoxManager.Instance.NoTalk == false)
        {
            TextBoxManager.Instance.NoTalk = true;
            TextBoxManager.Instance.DiologueBox.SetActive(true);
            TextBoxManager.Instance.Objportrait.SetActive(true);
            TextBoxManager.Instance.skip.SetActive(true);
            TextBoxManager.Instance.nameTextObj.SetActive(true);
            TextBoxManager.Instance.DialogPanel.SetActive(true);
            
            text.startDialogue();
        }
    }
}
