using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue; // Reference to the Dialogue scriptable object
    public DialogueManager dialogueManager; // Reference to the DialogueManager script
    private bool canInteract = false;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            InteractionMessageBehavior.instance.SetText("Aperte E para interagir", MessageType.Interact);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // End the dialogue when the player exits the trigger
            dialogueManager.EndDialogue();
            canInteract = false;
            InteractionMessageBehavior.instance.DeactiveText(MessageType.Interact);
        }
    }

    public void Update() {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.StartDialogue(dialogue);
            InteractionMessageBehavior.instance.DeactiveText(MessageType.Interact);
        }
    }
}
