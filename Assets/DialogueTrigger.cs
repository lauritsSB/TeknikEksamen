using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    bool dialogTriggered;
    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && dialogTriggered == false && Input.GetKey(KeyCode.E))
        {
            dialogTriggered = true;
            TriggerDialogue();
        }
    }

}
