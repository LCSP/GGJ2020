using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class show_hint_after_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img;
    void Start()
    {
        StartCoroutine(ChangeColor(img, new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), 3f));
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
        StartCoroutine(ChangeColor2(img, new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), 3f));
        
    }

    private IEnumerator ChangeColor2(Image image, Color from, Color to, float duration)
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
        SceneManager.LoadScene("lvl_1");
    }
}
