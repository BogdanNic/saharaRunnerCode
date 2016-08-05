using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SceneDetail : MonoBehaviour {

    public static event EventHandler ChangeScene;
    public static int sceneId;

	// Use this for initialization
	void Start () {

        print(sceneId);
       int id = SceneManager.GetActiveScene().buildIndex;

      //  if (id !=sceneId)
       // {
            if (ChangeScene != null)
            {
                ChangeScene(this, EventArgs.Empty);
                sceneId = id;    
            }
       // }
      
       
    }
	
}
