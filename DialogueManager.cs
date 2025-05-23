using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Text nameText;
    public PlayerMovement playerMovement;
    private Queue<string> sentences;
    private Queue<string> characterNames;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
        characterNames = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        sentences.Clear();
        characterNames.Clear();

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
            characterNames.Enqueue(dialogue.characterNames[i]);
        }

        if (playerMovement != null) playerMovement.SetFrozen(true);
        DisplayNextSentence();
    }

    void Update()
    {
        if (dialogueBox.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();//Fecha o diálogo
            return;
        }

        string sentence = sentences.Dequeue();
        string characterName = characterNames.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        nameText.text = characterName;
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter.ToString();
            yield return new WaitForSeconds(0.05f);//Velocidade de escrita
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        if (playerMovement != null) playerMovement.SetFrozen(false);
    }
}
