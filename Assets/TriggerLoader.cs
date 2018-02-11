using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoader : MonoBehaviour {

    public BoxCollider2D thisCol;
    public GameObject thisObj;
    public void OnTriggerEnter2D (Collider2D col) {


        if (col.tag == "Player")
        {
            GameManager.gameM.mainP.inCombat = true;
            SceneManager.LoadScene("BattleScene + BattleScene", LoadSceneMode.Additive);
            try
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("BattleScene + BattleScene"));
            }
            catch {

            }
                
        }

    }

}
