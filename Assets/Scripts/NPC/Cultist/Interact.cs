using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] GameObject storeCanvas;
    [SerializeField, TextArea(4, 6)] private string dialogueLines;
    [SerializeField] float typingTime;
    [SerializeField] int timeToText;
    private bool inRange = false;
    private int TimeToTextSaved;
    void Start()
    {
        TimeToTextSaved = timeToText;
        storeCanvas.SetActive(false);
        StartCoroutine(ShowLine());
        StartCoroutine(Lines());
    }
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.G))
        {
            storeCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
            StopAllCoroutines();
            inRange = true;
            timeToText = 1000000;
            dialogueLines = "OH, un cliente";
            StartCoroutine(ShowLine());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            storeCanvas.SetActive(false);
            inRange = false;
            timeToText = TimeToTextSaved;
            dialogueLines = "Gracias, vuelva pronto";
            StartCoroutine(ShowLine());
            StartCoroutine(Lines());
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        StopCoroutine(ShowLine());
    }
    private IEnumerator Lines()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(timeToText);
            dialogueLines = "No debi venir aqui abajo";
            StartCoroutine(ShowLine());
            yield return new WaitForSeconds(timeToText);
            dialogueLines = "Quien compra en este lugar?";
            StartCoroutine(ShowLine());
            yield return new WaitForSeconds(timeToText);
            dialogueLines = "Que calor hace...";
            StartCoroutine(ShowLine());
            yield return new WaitForSeconds(timeToText);
            dialogueLines = "Toc Toc. Quien es?. estoy solo...";
            StartCoroutine(ShowLine());
        }
        
    }
}
