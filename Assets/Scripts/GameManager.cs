using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager gameM;

    public Player mainP;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        gameM = this;
    }

  
    void Start() {
        NodeList n1 = new NodeList();
        Vector3 location = new Vector3(0, 0, 2);
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        Object.Instantiate(Resources.Load("OurPlayer"),location , rot);
        mainP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }

  
    void Update() {
        

    }

   

}
