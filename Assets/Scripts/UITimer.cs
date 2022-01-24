using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{

    public static UITimer instance { get; private set; }

    private float time = 11f;
    public Text display;
    public bool timeOver;
    public GameObject[] inst;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimer(time.ToString());
        timeOver = false;
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
        if (time != 0)
        {
            time -= Time.deltaTime;
            inst[0].SetActive(true);

            if (time <= 0)
            {
                time = 0;
                timeOver = true;   
            }
        
            if (time <= 9)
            {
                inst[0].SetActive(false);
                inst[1].SetActive(true);
                
            }
        
        UpdateTimer(Mathf.Floor(time).ToString());
        }
    }

    public void UpdateTimer(string time)
    {
        display.text = time;
    }

}
