using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Transform targetCharacter;
    public Vector3 offset = new Vector3(0, 2f, 0);
    public Camera mainCamera;
    
    private string[] sentences = new string[] 
    {
        "Welcome to NAME - Press E for next",
        "This is the tutorial where you will learn the basic controls before you dive into the ocean. - Press E for next",
        "Your movement will consist of using the AD (Maybe S) and space keys - Press E for next",
        "Hit A to move left and D to move right, Space to jump over obstacles - Press E to restart the dialogue",
    };
    
    private int currentSentenceIndex = 0;
    
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
            
        ShowCurrentSentence();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSentence();
        }
        

        UpdateDialoguePanelPosition();
    }

    void UpdateDialoguePanelPosition()
    {
        if (targetCharacter != null && dialoguePanel != null)
        {

            Vector3 screenPos = mainCamera.WorldToScreenPoint(targetCharacter.position + offset);
            

            dialoguePanel.transform.position = screenPos;
        }
    }

    void ShowCurrentSentence()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = sentences[currentSentenceIndex];
    }

    void NextSentence()
    {
        currentSentenceIndex = (currentSentenceIndex + 1) % sentences.Length;
        ShowCurrentSentence();
    }
}