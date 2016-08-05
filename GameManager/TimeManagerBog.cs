using UnityEngine;
using System.Collections;

public class TimeManagerBog : MonoBehaviour {

    public Gradient groundGradient, equatorGradient, skyGradient;
   // private TimeOfDayManager m_TimeOfDayManager;
    public float currentTime;
    public Material skyMaterial;
    public AnimationCurve skyExposure;
    public AnimationCurve sunExposure;
    public float timeIn;
    public float time;
    public float skyExposureMult = 15;
    public float sunExposureMult = 150;
    public GameObject EmisiveObj;
    void OnEnable()
    {
      //  m_TimeOfDayManager = FindObjectOfType<timeofdaymanager>();
    }

    void Update()
    {
      //  float currentTime = m_TimeOfDayManager.time;
        RenderSettings.ambientGroundColor = groundGradient.Evaluate(currentTime);
        RenderSettings.ambientEquatorColor = equatorGradient.Evaluate(currentTime);
        RenderSettings.ambientSkyColor = skyGradient.Evaluate(currentTime);
        skyMaterial.SetFloat("_RotationPitch2", Mathf.Lerp(180, -180, time * 1.25f)); //TODO look up max automatically for this to loop instead of 1.25
        skyMaterial.SetFloat("_Exposure", skyExposure.Evaluate(timeIn) * skyExposureMult);
        skyMaterial.SetFloat("_SunExposure", sunExposure.Evaluate(timeIn) * sunExposureMult);

    }
    public void GI_Run()
    {
        Renderer rend = EmisiveObj.GetComponent<Renderer>();

        DynamicGI.SetEmissive(rend, Color.blue);
        print("Run Update");
    }

}
