
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueAdm : MonoBehaviour
{

    public Image image;
    public Text dialogueTxt;
    public GameObject dialogueBox;
    private AudioSource npcVoice;
    //Fila com as setenças 
    public Queue<string> sentences;
    private PlayerController player;

    void Start()
    {
        sentences = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        npcVoice = GetComponent<AudioSource>();
    }

    public void StartDialogue(DialogueThings dialogue)
    {
        //Ativa caixa de dialogo
        dialogueBox.SetActive(true);
        //playerTalkin fica true
        player.talking = true;
        //zera a velocidade 
        player.curSpeed = 0;
        //Iguala
        image.sprite = dialogue.img;
        npcVoice.clip = dialogue.voice;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)

        {
            sentences.Enqueue(sentence);
        }

        NextSentence();

    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LetterByLeter(sentence));
    }

    IEnumerator LetterByLeter(string sentence)
    {
        dialogueTxt.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTxt.text += letter;
            npcVoice.Play();
            yield return new WaitForSeconds(0.1f);

        }

    }

    void EndDialogue()
    {
        print("Anda porra");
        player.curSpeed = player.maxSpeed;
        dialogueBox.SetActive(false);
        player.talking = false;
    }
}
