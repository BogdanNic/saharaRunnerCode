using UnityEngine;
using System.Collections;

public class GameManager {

    private static GameManager _instance;

    public  PlayerPowers playerPower;

  
    public  static GameManager Instance
    {
        get
        {
            if (_instance== null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
}
