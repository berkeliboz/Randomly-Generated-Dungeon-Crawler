using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {

    public GameObject targetAttackPosObj;

    Quaternion aq = new Quaternion(0, 0, 0,0);

    void Start() {

        targetAttackPosObj = GameObject.FindGameObjectWithTag("enemy");
        return;
    }


    public void ice0()
    {
        Object.Instantiate(Resources.Load("ice0"), targetAttackPosObj.transform.position ,aq);

    }
    public void ice1()
    {
        Object.Instantiate(Resources.Load("ice1"), targetAttackPosObj.transform.position, aq);

    }
    public void ice2()
    {
        Object.Instantiate(Resources.Load("ice2"), targetAttackPosObj.transform.position, aq);

    }
    public void fire0()
    {
        Object.Instantiate(Resources.Load("fire0"), targetAttackPosObj.transform.position, aq);

    }
    public void fire1()
    {
        Object.Instantiate(Resources.Load("fire1"), targetAttackPosObj.transform.position, aq);

    }
    public void fire2()
    {
        Object.Instantiate(Resources.Load("fire2"), targetAttackPosObj.transform.position, aq);

    }
    public void poison0()
    {
        Object.Instantiate(Resources.Load("poison0"), targetAttackPosObj.transform.position, aq);

    }
    public void poison1()
    {
        Object.Instantiate(Resources.Load("poison1"), targetAttackPosObj.transform.position, aq);

    }
    public void poison2()
    {
        Object.Instantiate(Resources.Load("poison2"), targetAttackPosObj.transform.position, aq);

    }
    public void bleedAttack()
    {
        Object.Instantiate(Resources.Load("bleeding"), targetAttackPosObj.transform.position, aq);

    }



}
