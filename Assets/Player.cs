using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public AudioSource bgm;

	// Use this for initialization
	void Start () {
		bgm.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCallMusicPlay( string state )
	{
		switch(state)
		{
		case "play":
			bgm.Play();
			break;
		case "stop":
			bgm.Stop();
			break;
		}
	}
}
