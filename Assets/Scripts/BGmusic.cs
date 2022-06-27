using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    public static bool pause;
    public GameObject musicPlayer;
    public static float time;
    public GameObject mute;
    public GameObject muted;
    

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        musicPlayer.GetComponent<AudioSource>().time = time;
        musicPlayer.GetComponent<AudioSource>().mute = pause;
        mute = GameObject.Find("Mute Button");
        muted = GameObject.Find("Muted Button");
        if (pause){
            mute.transform.SetAsFirstSibling();
        }
        else{
            muted.transform.SetAsFirstSibling();
        }
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
            mute.transform.SetAsFirstSibling();
        }
        else if (pause == true){
            pause = false;
            musicPlayer.GetComponent<AudioSource>().mute = false;
            muted.transform.SetAsFirstSibling();
        }
    }

    public static void playSoundEffect(AudioClip soundEffect){
        GameObject soundEffectPlayer = new GameObject();
        soundEffectPlayer.AddComponent<AudioSource>();
        if (pause == false){
            soundEffectPlayer.GetComponent<AudioSource>().PlayOneShot(soundEffect);
        }
    }
}
