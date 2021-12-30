using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{
    [SerializeField] private float speed = 50f;

    public Coroutine Run(string text, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(text, textLabel));
    }

    private IEnumerator TypeText(string text, TMP_Text textLabel)
    {
        float t = 0f;
        int charIndex = 0;

        while (charIndex < text.Length)
        {
            t += Time.deltaTime * speed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            textLabel.text = text.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = text;
    }
}
