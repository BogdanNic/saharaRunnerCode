using UnityEngine;
using System.Collections;

public class AutoIntensity : MonoBehaviour {

    public Gradient nightDayColor;

    public float maxIntensity = 3f;
    public float minIntensity = 0f;
    public float minPoint = -0.2f;

    public float maxAmbient = 1f;
    public float minAmibient = 0f;
    public float minAmbientPoint = -0.2f;

    public Gradient nightDayColorFogColor;
    public AnimationCurve fogDensityCurve;
    public float fogScale = 1f;

    public float dayAtmonsphereThichness = 0.4f;
    public float nightAtmosphereThikness = 0.87f;

    public Vector3 dayRotateSpeed;
    public Vector3 nightRotateSpeed;


    Light mainLight;
    Skybox sky;
    Material skyMaterial;
    private float skySpeed=1f;

    // Use this for initialization
    void Start () {
        mainLight = GetComponent<Light>();
        skyMaterial = RenderSettings.skybox;
	}

    // Update is called once per frame
    void Update()
    {
        //cat dureaza o zi
        float tRange = 1 - minPoint;
        float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
        float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        mainLight.intensity = i;

        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmibient) * dot) + minAmibient;
        RenderSettings.ambientIntensity = i;

        mainLight.color = nightDayColor.Evaluate(dot);
        RenderSettings.ambientLight = mainLight.color;

        RenderSettings.fogColor = nightDayColorFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

        i = ((dayAtmonsphereThichness - nightAtmosphereThikness) * dot) + nightAtmosphereThikness;
        skyMaterial.SetFloat("_AtmosphereThickness", i);

        if (dot > 0)
        {
            transform.Rotate(dayRotateSpeed * Time.deltaTime * skySpeed);
        }
        else
        {
            transform.Rotate(nightRotateSpeed * Time.deltaTime * skySpeed);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            skySpeed *= 0.5f;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            skySpeed *= 2f;

        }
    }
        
}
