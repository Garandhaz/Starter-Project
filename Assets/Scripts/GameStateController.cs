using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance { get; private set; }

    public AudioSource musicSource;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip bgm;
    ParticleSystem lights;

    public GameObject[] text;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
        musicSource.loop = true;
        lights = GetComponentInChildren<ParticleSystem>();
        lights.Stop();
        WinCondition();
        text[0].SetActive(false);
        LoseCondition();
        text[1].SetActive(false);


    }

    void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }
        // which is a special C# keyword that means “the object that currently runs that function”.
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WinCondition()
    {
        musicSource.clip = win;
        musicSource.Play();
        text[0].SetActive(true);
    }

    public void LoseCondition()
    {

       if (UITimer.instance.timeOver = true)
        {
            musicSource.clip = bgm;
            musicSource.Play();
            text[1].SetActive(true);
        }
    }

}
