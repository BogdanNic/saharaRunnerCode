using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Menu currentManu;
    void Start()
    {
        // OpenMenu(currentManu);
        currentManu.gameObject.SetActive(true);
    }

	public void OpenMenu(Menu menu)
    {
        print("open menu");
        currentManu.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);

        currentManu = menu;
       // gma.SetActive(true);
    }

}
