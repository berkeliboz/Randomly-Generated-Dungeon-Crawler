using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour {

    public bool isPlayerTurn = false;
    public Mob enemyAI;
    public float turnTimer = 3;
    private Quaternion qt = new Quaternion(0, 0, 0, 0);
    public GameObject enemyPlaceHolder;


    void Start() {


        enemyAI = GetComponent<Mob>();
        turnTimer = 3;

        Object.Instantiate(Resources.Load(Player.current),enemyPlaceHolder.transform.position,qt);

    }

    void Update() {
        
        turnTimer -= Time.deltaTime;
        if (turnTimer <= 0 )
        {
            try
            {
                GameManager.gameM.mainP.inCombat = false;
            }
            catch {
            }


            SceneManager.UnloadScene("BattleScene + BattleScene");
        }
    }

}
