using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    public static bool pause;
    public GameObject musicPlayer;
    public static float time;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        musicPlayer.GetComponent<AudioSource>().time = time;
        musicPlayer.GetComponent<AudioSource>().mute = pause;
    }

    // Update is called once per frame
    void Update()
    {
        time = musicPlayer.GetComponent<AudioSource>().time;
    }

    public void muteButton(){
        if (pause == false){
            pause = true;
            musicPlayer.GetComponent<AudioSource>().mute = true;
        }
        else if (pause == true){
            pause = false;
            musicPlayer.GetComponent<AudioSource>().mute = false;
        }
    }
}
