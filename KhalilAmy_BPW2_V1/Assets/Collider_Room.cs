using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Room : MonoBehaviour
{

    private bool IsNight; 
    public Material DaySkybox; 
    public Material NightSkybox; 
    public AudioClip GreekMusic; 
    private AudioSource muziekSpeler; 
    private bool muziekGespeeld;

    // Start is called before the first frame update
    void Start()
    {
        muziekSpeler = this.gameObject.GetComponent<AudioSource>();
        RenderSettings.skybox = DaySkybox;      
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TriggerRoomBox")
        {
            if(IsNight){
                RenderSettings.skybox = DaySkybox; 
            }
            else{
                RenderSettings.skybox = NightSkybox;
            }
            IsNight = !IsNight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(muziekGespeeld == false){
            if(other.gameObject.tag == "TriggerRoomBox") {
                muziekSpeler.clip = GreekMusic;
                muziekSpeler.Play(0);
		        muziekGespeeld = true; 
            }
      }
       
    }

}
