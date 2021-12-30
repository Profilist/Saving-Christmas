using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField] Image[] controls;
    public void ShowInstructions()
    {
        foreach (Image image in controls)
        {
            image.enabled = true;
        }
    }
    public void CloseInstructions()
    {
        foreach (Image image in controls)
        {
            image.enabled = false;
        }
    }
}
