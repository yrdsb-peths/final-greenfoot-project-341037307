using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public bool isShrine;
    public GameObject Player;

    public float wordSpeed;
    public bool playerClose;
    private bool broken;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                broken = true;
                zeroText();
            }
            else
            {
                broken = false;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true); 
        }
    }

    // Reset Text and closes the panel
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    // types the line at float wordSpeed. If the user is speaking to the keeper of hearts, change scene to menu
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            if (broken)
            {
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if (isShrine)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Menu");
        }
    }

    // if there is dialogue, start typing the next one. Else zero the text.
    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            broken = true;
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
            broken = true;
            zeroText();
        }
    }
}
