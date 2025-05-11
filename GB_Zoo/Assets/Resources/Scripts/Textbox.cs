using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Textbox : MonoBehaviour
{
    public Image textbox;
    public TextMeshProUGUI text;
    public Image continueSymbol;
    public float textSpeed;
    public string message;
    private int textIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Dialogue();
        }
    }

    public void Dialogue()
    {
        textbox.enabled = true;
        text.text = "";
        textIndex = 0;
        continueSymbol.gameObject.SetActive(false);
        StartCoroutine(PrintLetter());
    }

    IEnumerator PrintLetter()
    {
        yield return new WaitForSeconds(textSpeed);
        text.text += message.Substring(textIndex, 1);
        
        if (textIndex < message.Length - 1)
        {
            textIndex++;
            StartCoroutine(PrintLetter());
        }
    }
}
