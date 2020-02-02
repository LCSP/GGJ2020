using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossfight : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    //public GameObject text;
    public GameObject spawner;
    public int enemiesAmount;

    public AudioSource auSource;
    public AudioSource auSoruceLevel;

    public List<GameObject> Enemies;

    public List<Sprite> texts;

    public List<AudioClip> clips;

    public int EnemiesCount = 30;

    public Image TextContainer;

    public static bossfight INSTANCE;
    // Start is called before the first frame update
     void Awake()
    {
        EnemiesCount = enemiesAmount;
        INSTANCE = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesCount <= 0)
        {
            SceneManager.LoadScene("end_game");
        }
    }

    public void startBossfight()
    {
        StartCoroutine(BossFightRoutine());
    }


    IEnumerator BossFightRoutine()
    {
        TextContainer.enabled = true;
        Camera.main.GetComponent<CameraFollow>().target = boss.transform;
        for (int i = 0; i < texts.Count; i++)
        {
            //texts[i].SetActive(true);
            TextContainer.sprite = texts[i];
            
            //TextContainer.GetComponent<RectTransform>().rect = new Rect(; 
            auSource.clip = clips[i];
            auSource.Play();
            yield return new WaitForSeconds(2f);
        }
        TextContainer.enabled = false;
        for (int i = 0; i < enemiesAmount; i++)
        {
            int rnd = Random.Range(0, Enemies.Count);
            GameObject tempOb = Instantiate(Enemies[rnd], spawner.transform.position + Random.insideUnitSphere * 100, Quaternion.identity);
            tempOb.transform.tag = "BossEnemie";
            Camera.main.GetComponent<CameraFollow>().target = tempOb.transform;
            yield return new WaitForSeconds(1);
        }
        Camera.main.GetComponent<CameraFollow>().target = player.transform;
        auSource.clip = clips[clips.Count - 1];
        auSource.loop = true;
        auSoruceLevel.Stop();
        auSource.Play();

        
    }
}
