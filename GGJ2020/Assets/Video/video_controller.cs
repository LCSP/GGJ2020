using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video_controller : MonoBehaviour
{

    public VideoClip video1;
    public VideoClip video2;
    public VideoClip video3;
    public VideoClip video4;
    public VideoPlayer vPlayer;
    public GameObject cube;
    public AudioSource auSource;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("videochange", 0, 3);
        InvokeRepeating("showvideo", 2, 3);
    }

    // Update is called once per frame
    void videochange()
    {
        int rnd = Random.Range(1, 3);
        if (rnd == 1)
        {
            vPlayer.clip = video1;
            vPlayer.Play();
        }
        if (rnd == 2)
        {
            vPlayer.clip = video2;
            vPlayer.Play();
        }
        /*if (rnd == 3)
        {
            vPlayer.clip = video3;
            vPlayer.Play();
        }
        if (rnd == 4)
        {
            vPlayer.clip = video4;
            vPlayer.Play();
        }*/
    }

    void showvideo()
    {
        StartCoroutine(ShowCube());
    }

    IEnumerator ShowCube()
    {
        //This is a coroutine
        cube.active = true;
        auSource.Play();
        yield return new WaitForSeconds(1);    //Wait one frame

        cube.active = false;
    }
}
