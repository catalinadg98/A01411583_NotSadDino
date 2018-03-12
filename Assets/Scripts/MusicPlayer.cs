using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	MusicPlayer instance;

	void Start () {
		if (instance != null) 
		{
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
}
