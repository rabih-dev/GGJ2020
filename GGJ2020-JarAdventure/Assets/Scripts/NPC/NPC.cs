using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public DialogueThings dialogue;

    //private DialogueAdm dialogueAdm;
    //public string name;
    //
    public GameObject dialogueBox;
    public GameObject pressToTalk;
    //Instanciou o Player aqui pra pegar a variavel booleana Talking
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    void OnTriggerStay(Collider coll)
    {
        #region InputPraStartarDialogo
        pressToTalk.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E) && coll.tag == "Player")
        {
            if (!dialogueBox.activeSelf)
            {
                FindObjectOfType<DialogueAdm>().StartDialogue(dialogue);
            }

            else
            {
                //Vai no DialogueManager e entra em NextSentence
                FindObjectOfType<DialogueAdm>().NextSentence();

            }
        }
        #endregion
    }

    //Pra quando sair a teclinha não ficar ativa
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            pressToTalk.SetActive(false); ;
        }

    }
}