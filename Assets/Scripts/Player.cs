using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {

    public static string[] mobsArray = new string[4];

    public static string current = mobsArray[0];

    public static Player instance;
    public Animator myAnim;
    public Transform myTransform;

    public float movSpeedH;
    public float movSpeedV;

    public Vector3 velocity = new Vector3(0,0,0);
    public Vector3 accel = new Vector3(0, 0, 0);
    public Vector3 maxVel = new Vector3(0,0, 0);

    public bool facingRight;

    public bool inCombat;

    public GameObject fightPanel;


    // Beginning of stats

    public string className = "Ice";
    public int classNum = 0;
    public int baseHP = 100;
    public int baseMana = 100;
    public int baseArmor = 30;
    public int level = 1;
    public int totalHP;
    public int bonusDamage;
    public bool isAlive;
    public int speed = 1;
    public int attackNum = 3;
    public int currentHP;

    // End of stats

    public void setClass(int classNum)
    {
        this.classNum = classNum;
        if (classNum == 0)
        {
            className = "Ice";

        }

        else if (classNum == 1)
        {
            className = "Fire";
        }

        else if (classNum == 2) {
            className = "Poison";
        }
        
    }



    public void OnTriggerEnter2D(Collider2D col) {
        for (int i = 0; i < mobsArray.Length; i++) {
            if (col.gameObject.tag == mobsArray[i]) {
                current = mobsArray[i];

                Debug.Log(mobsArray[i]);
                Debug.Log("looped");
            }
            
        }
        

    }
    


    void Start()
    {

        mobsArray[0] = "alch";
        mobsArray[1] = "berserker";
        mobsArray[2] = "flame";
        mobsArray[3] = "lava";


        instance = this;
        facingRight = true;
        inCombat = false;
        totalHP = baseHP + baseMana;
        currentHP = totalHP;
    }


    void FixedUpdate()
    {

        float horizontal = 0;
        float vertical = 0;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        float velFloat = Mathf.Sqrt((velocity.x * velocity.x)+(velocity.y * velocity.y));
        myAnim.SetFloat("speed", velFloat);
        HandleMovement(horizontal,vertical);
        if (currentHP <= 0)
        {
            isAlive = false;
        }
        HandleAnim();
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        if (!inCombat)
        {
            if (horizontal != 0)
            {
                float tempX = myTransform.position.x;
                accel = new Vector3((horizontal * movSpeedH), 0, 0) * Time.deltaTime;
                if (Mathf.Abs(accel.x) > maxVel.x)
                {
                    if (accel.x >= 0)
                        accel.x = maxVel.x;
                    else
                        accel.x = (-1 * maxVel.x);
                }
                velocity.x += accel.x;
                if (Mathf.Abs(velocity.x) > maxVel.x)
                {
                    if (velocity.x >= 0)
                        velocity.x = maxVel.x;
                    else
                        velocity.x = (-1 * maxVel.x);
                }
                myTransform.position += new Vector3(velocity.x,0);
            }
            if (horizontal == 0)
                velocity.x = 0;
            if (vertical != 0)
            {
                float tempY = myTransform.position.y;
                accel = new Vector3(0, (vertical * movSpeedV), 0) * Time.deltaTime;
                if (Mathf.Abs(velocity.y) > maxVel.y)
                {
                    if (accel.y >= 0)
                        accel.y = maxVel.y;
                    else
                        accel.y = (-1 * maxVel.y);
                }
                accel.Normalize();
                velocity.y += accel.y;
                if (Mathf.Abs(velocity.y) > maxVel.y)
                {
                    if (velocity.y >= 0)
                        velocity.y = maxVel.y;
                    else
                        velocity.y = (-1 * maxVel.y);
                }
                myTransform.position += new Vector3(0,velocity.y);
            }
            if (vertical == 0)
                velocity.y = 0;
            if (velocity.x > 0 && facingRight || velocity.x < 0 && !facingRight)
            {
                facingRight = !facingRight;
                float temp = myTransform.localScale.x;
                temp *= -1;
                myTransform.localScale = new Vector3(temp, myTransform.localScale.y);
            }
        }
    }

    public void HandleAnim()
    {
        if (inCombat)
        {
            if (Input.GetButtonDown("MainAttack"))
                myAnim.SetTrigger("attack");
            if (Input.GetButtonDown("Skill"))
                myAnim.SetTrigger("skillAttack");
        }
    }

    public void ResetTrig()
    {

        myAnim.ResetTrigger("attack");
        myAnim.ResetTrigger("skillAttack");
    }


    public int doDamage()
    {
        return Random.Range(1, 6) * 9 + bonusDamage;

    }

    public void takeDamage(int damage)
    {
        if (baseArmor > 0)
        {
            baseArmor -= damage;
            if (baseArmor < 0)
            {
                baseHP += baseArmor;
                baseArmor = 0;
            }
        }
        else
        {
            baseHP -= damage;
        }
    }


}

