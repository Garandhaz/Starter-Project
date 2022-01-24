using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : MonoBehaviour
{   

    public static KeyBoardController instance { get; private set; }

    public AudioSource musicSource;
    public AudioClip[] notes;
    public Animator[] keys; // [] creates an array/list to add game objects into
    public ParticleSystem[] lights;
    public KeyCode[] noteKeyCode; //turn enumeration KeyCode event function into an array

    // Start is called before the first frame update
    void Start()
    {
        noteKeyCode = new KeyCode[12]; //define noteKeyCode as every KeyCode inside the array of [12]
        noteKeyCode[0] = KeyCode.Q;
        noteKeyCode[1] = KeyCode.W;
        noteKeyCode[2] = KeyCode.E;
        noteKeyCode[3] = KeyCode.R;
        noteKeyCode[4] = KeyCode.T;
        noteKeyCode[5] = KeyCode.Y;
        noteKeyCode[6] = KeyCode.U;
        noteKeyCode[7] = KeyCode.Alpha2;
        noteKeyCode[8] = KeyCode.Alpha3;
        noteKeyCode[9] = KeyCode.Alpha5;
        noteKeyCode[10] = KeyCode.Alpha6;
        noteKeyCode[11] = KeyCode.Alpha7;
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
        for (int i = 0; i < 12; i++)
        {
            CheckNote(i);
        }

        if (Input.GetKey("escape")) // quit game
        {
          Application.Quit();
        }        
    }

    void CheckNote(int index)
    {
        if (Input.GetKeyDown(noteKeyCode[index]))
            {
            musicSource.PlayOneShot(notes[index], 3);
            keys[index].SetBool("Pressed", true);
            lights[index].Play();
            }

        if (Input.GetKeyUp(noteKeyCode[index]))
            {
            keys[index].SetBool("Pressed", false);
            lights[index].Stop();
            }
    }
}
