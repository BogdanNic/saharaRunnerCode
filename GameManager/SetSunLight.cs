using UnityEngine;
using System.Collections;

public class SetSunLight : MonoBehaviour {


    public Renderer lightWall;
    Material sky;

    public Renderer water;

    public Transform stars;
    public Transform worlProbe;

	// Use this for initialization
	void Start () {
        sky = RenderSettings.skybox;
	}
    bool lightOn=false;
	// Update is called once per frame
	void Update () {
        stars.transform.rotation = transform.rotation;
        if (Input.GetKeyDown(KeyCode.A))
        {
            lightOn = true;
        }
        if (lightOn)
        {
            Color final = Color.white * Mathf.LinearToGammaSpace(15);
            lightWall.material.SetColor("_EmissionColor", final);
            DynamicGI.SetEmissive(lightWall, final);
        }
        else
        {
            Color final = Color.white * Mathf.LinearToGammaSpace(0);
            lightWall.material.SetColor("_EmissionColor", final);
            DynamicGI.SetEmissive(lightWall, final);
        }

    }
}
