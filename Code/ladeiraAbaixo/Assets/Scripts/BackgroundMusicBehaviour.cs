using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicBehaviour : MonoBehaviour {

    public static BackgroundMusicBehaviour controlMusic = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        if(controlMusic != null)
        {
            Destroy(gameObject);
        }
        else
        {
            controlMusic = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
