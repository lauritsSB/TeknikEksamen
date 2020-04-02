using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    bool dialogTriggered;
    DialogueManager dm;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }
    public void TriggerDialogue ()
    {
        dm.StartDialogue(dialogue);
    }

    public GameObject dialogueWindow;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && dialogTriggered == false && Input.GetKeyDown(KeyCode.E))
        {
            dialogueWindow.SetActive(true);
            dialogTriggered = true;
            TriggerDialogue();
        }
        if(other.tag=="Player" && dialogTriggered==true && Input.GetKeyDown(KeyCode.E))
        {
            dm.DisplayNextSentence();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dialogueWindow.SetActive(false);
    }
}
