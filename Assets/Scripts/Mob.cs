using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mob: MonoBehaviour{

    public static Mob enemyInst;
    public  Player targetAttackPosObj;
    public string className = "ice";

    public int baseHP = 100;
    public int baseMana = 100;
    public int baseArmor = 30;
    public int level = 1;
    public int totalHP;

    public int bonusDamage;

    public bool isAlive;
    public int currentHP;


    void Start() {
        isAlive = true;
        enemyInst = this;
        totalHP = baseHP + baseMana;
        bonusDamage = level * 10;
    }

    void Update()
    {

        if(currentHP <= 0)
        {
            isAlive = false;
        }

    }

    public int doDamage() {
        return Random.Range(1, 6)*9 + bonusDamage;
        
    }

    public void takeDamage( int damage) {
        if (baseArmor > 0)
        {
            baseArmor -= damage;
            if (baseArmor < 0) {
                baseHP += baseArmor;
                baseArmor = 0;
            }
        }
        else {
            baseHP -= damage;
        }
    }

    public void mobDoTurn()
    {
        int n = Random.Range(0, 3);
        if (n == 3)
            bleedAttack();

        else if (className == "ice")
        {
            switch (n)
            {
                case 0:
                    ice0();
                    return;
                case 1:
                    ice1();
                    return;
                case 2:
                    ice2();
                    return;
                default:
                    ice0();
                    return;
            }
        }
        else if (className == "fire")
        {
            switch (n)
            {
                case 0:
                    fire0();
                    return;
                case 1:
                    fire1();
                    return;
                case 2:
                    fire2();
                    return;
                default:
                    fire0();
                    return;
            }

        }
        else if (className == "poison") {
            switch (n)
            {
                case 0:
                    poison0();
                    return;
                case 1:
                    poison1();
                    return;
                case 2:
                    poison2();
                    return;
                default:
                    poison0();
                    return;
            }

        }

   }




    public void ice0() {
        Object.Instantiate(Resources.Load("ice0"), targetAttackPosObj.transform);

    }
    public void ice1()
    {
        Object.Instantiate(Resources.Load("ice1"), targetAttackPosObj.transform);

    }
    public void ice2()
    {
        Object.Instantiate(Resources.Load("ice2"), targetAttackPosObj.transform);

    }
    public void fire0()
    {
        Object.Instantiate(Resources.Load("fire0"), targetAttackPosObj.transform);

    }
    public void fire1()
    {
        Object.Instantiate(Resources.Load("fire1"), targetAttackPosObj.transform);

    }
    public void fire2()
    {
        Object.Instantiate(Resources.Load("fire2"), targetAttackPosObj.transform);

    }
    public void poison0()
    {
        Object.Instantiate(Resources.Load("poison0"), targetAttackPosObj.transform);

    }
    public void poison1()
    {
        Object.Instantiate(Resources.Load("poison1"), targetAttackPosObj.transform);

    }
    public void poison2()
    {
        Object.Instantiate(Resources.Load("poison2"), targetAttackPosObj.transform);

    }
    public void bleedAttack()
    {
        Object.Instantiate(Resources.Load("bleeding"), targetAttackPosObj.transform);

    }


}
