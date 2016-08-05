using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SelectCharacter : MonoBehaviour {

    public  TouchPadBog touch;

    public float touchSmothing=10f;

    public GameObject[] characters;

    public PlayerPowers[] powers;


    public Text speed;
    public Text steangth;
    public Text power;

    private int nr=0;
    private int idPlayer = 0;
   private LevelManager manager;
    

	// Use this for initialization
	void Start () {

       GameObject managerB = GameObject.FindGameObjectWithTag("LevelManager");
        if (managerB != null)
        {
          manager=managerB.GetComponent<LevelManager>();
        }
        characters[nr].SetActive(true);
        manager.SetPlayerID(powers[0]);
    }

    void FixedUpdate()
    {
        
        Vector2 direction = touch.GetDirection();
        if (direction.x != 0f)
        {
            transform.Rotate(Vector3.up, -direction.x * touchSmothing);
        }
        
    }
    public void NextCharacter()
    {
        characters[idPlayer].SetActive(false);
        nr--;
        idPlayer = nr % characters.Length;
        if (idPlayer<0)
        {
            idPlayer *= -1;
        }
        print("next" + idPlayer);
        characters[idPlayer].SetActive(true);
        print("nr"+nr);
        ShowPowers(idPlayer);

    }
    public void PreviosCharacter()
    {
        characters[idPlayer].SetActive(false);
        nr++;
         idPlayer = nr % characters.Length ;
        if (idPlayer < 0)
        {
            idPlayer *= -1;
        }
        print("previous"+idPlayer);
        characters[idPlayer].SetActive(true);
        print("nr" + nr);
        ShowPowers(idPlayer);
    }

    private void ShowPowers(int i)
    {
        speed.text = powers[i].speed.ToString();
        steangth.text = powers[i].streangth.ToString();
        power.text = powers[i].power.ToString();
        manager.SetPlayerID(powers[i]);
    }
    // Update is called once per frame
    void Update () {
       
	}
}
