using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void test()
    {
        if (!source.isPlaying)
        {
            source.pitch = Random.Range(0.5f, 0.8f);
            source.volume = Random.Range(0.4f, 0.7f);
            source.Play();
        }
    }
    public void test2()
    {

    }
}
