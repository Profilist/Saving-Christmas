using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBoundaries;
    private SpriteRenderer sr;
    private float objWidth;
    private float objHeight;

    void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sr = transform.GetComponent<SpriteRenderer>();
        objWidth = sr.bounds.size.x/2;
        objWidth = sr.bounds.size.y/2;
    }

    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBoundaries.x + objWidth, screenBoundaries.x * -1 - objWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBoundaries.y + objHeight, screenBoundaries.y * -1 - objHeight);
        transform.position = viewPosition;
    }
}
