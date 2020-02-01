using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class black_screen : MonoBehaviour
{
    public Image panelBlack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ChangeColor(panelBlack, new Color32(0,0,0,0), new Color32(0, 0, 0, 255), 1.5f));
    }

    private IEnumerator ChangeColor(Image image, Color from, Color to, float duration)
    {
        float timeElapsed = 0.0f;

        float t = 0.0f;
        while (t < 1.0f)
        {
            timeElapsed += Time.deltaTime;

            t = timeElapsed / duration;

            image.color = Color.Lerp(from, to, t);

            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("ChangeColor");
        StartCoroutine(ChangeColor(panelBlack, new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 0), 1.5f));

    }
}
