using System.Collections;
using System.Collections.Generic;

using UnityEngine;




public class CustomMatrix {

    public int row = 2;
    public int column = 2;
    public bool[] boolList = new bool[4];

    public int getSize() { return row * column;}

    public CustomMatrix(int x, int y) {
        row = x;
        column = y;
        bool[] boolList = new bool[x * y];
    }



}

public class Node{

    public CustomMatrix defMatrix;
    int letterRandom = Random.Range(0, 2);
    public int constantVal = 0;
    public int linkerVal = 3;

    public Node next = null;
    public Node previous = null;

    public Vector2 pos = new Vector2(0, 0);

    public void printNodePos() {
        Debug.Log("x: " + pos.x + " y: " + pos.y);
    }

    public void printNode() {
        Debug.Log("[" + defMatrix.boolList[0] + "," + defMatrix.boolList[1] + "]");
        Debug.Log("[" + defMatrix.boolList[2] + "," + defMatrix.boolList[3] + "]");

        Debug.Log("[            ]");

    }

    public Node()
    {
         defMatrix = new CustomMatrix(2,2);
         constantVal = 0;
         next = null;
         previous = null;
         pos = new Vector2(0, 0);
        linkerVal = 3;
        

    }


    public Node( int x, int y, Node prv, Node nxt, CustomMatrix mx, int constVal) {
        defMatrix = mx;
        previous = prv;
        next = nxt;
        pos.x = x;
        pos.y = y;
        constantVal = constVal;

    }
  

    public void matrixAssignerStart()
    {

        int size = 4;

        for (int i = 0; i < size; i++)
        {
            defMatrix.boolList[i] = false;
        }

        int r1 = Random.Range(0, 3);
        defMatrix.boolList[r1] = true;
        this.constantVal = r1;
        linkerVal = constantVal;
        fixNodePos();
    }


    public void fixNodePos()
    {
        if (this.previous == null)
            return;
        else
        {
            float x = this.previous.pos.x;
            float y = this.previous.pos.y;


            switch (this.previous.linkerVal)
            {
                case 0:
                    this.pos.Set(x, y + 1);
                    return;
                case 1:
                    this.pos.Set(x + 1, y);
                    return;
                case 2:
                    this.pos.Set(x - 1, y );
                    return;
                case 3:
                    this.pos.Set(x , y - 1);
                    return;
                default:
                    return;

            }

        }

    }


    public void assignIntroLink() {
        if (previous == null){
            return;
        }
        else {
            int checker = previous.linkerVal;
            switch (checker)
            {
                case 0:
                    constantVal = 3;
                    return;
                case 1:
                    constantVal = 2;
                    return;
                case 2:
                    constantVal = 1;
                    return;
                case 3:
                    constantVal = 0;
                    return;
                default:
                    Debug.LogError("Intro assign bug found");
                    return;
            }
        }



    }

    public bool oldNodeChecker(Node check)
    {
        Node tempNode = check;
        bool temp = true;
        //for(int i=0; i < 3; i++)
        while(tempNode != null)
        {
            if (check != null && tempNode != null)
            {
                if (check.pos == tempNode.pos)
                    temp = false;
                tempNode = tempNode.previous;
            }

        }
        return temp;
    }
 
    public void matrixAssigner()
    {
        assignIntroLink();
        int size = 4;

        for (int i = 0; i < size; i++)
        {
            defMatrix.boolList[i] = false;
        }

        defMatrix.boolList[constantVal] = true;

        int r0 = Random.Range(0, 3);
        while (r0 == constantVal) //&& add square checker later
        {
            r0 = Random.Range(0, 3);
        }
        linkerVal = r0;
        fixNodePos();
        while (r0 == constantVal) //&& add square checker later
        {
            while (!oldNodeChecker(this))
            {
                r0 = Random.Range(0, 3);
            }
        }
        defMatrix.boolList[r0] = true;
        linkerVal = r0;
        fixNodePos();
    }
    public void instantiateMap()
    {
        
        Quaternion rot = new Quaternion(0, 0, 0,0);
        int[] array = new int[5];
        string code;
        for (int i= 0; i<4;i++)
        {
            if(defMatrix.boolList[i])
            {
                array[i] = 1;
            }
            if (!defMatrix.boolList[i])
            {
                array[i] = 0;
            }
        }
        code = array[0].ToString() + array[1].ToString() + array[2].ToString() + array[3].ToString() + varSpawn() ;
        Vector3 location = new Vector3((7.19998f) * pos.x, (5.1999f) * pos.y,-3);
        GameObject tempParentObj = Object.Instantiate(Resources.Load(code), location, rot) as GameObject;
        if (tempParentObj.transform.Find("EnemySpawn") != null)
        {
            Transform transform = tempParentObj.transform.Find("EnemySpawn");
            string temp = mobSpawn();
            Object.Instantiate(Resources.Load(temp), transform);
        }
    }
    public string varSpawn()
    {
        string temp = "a";
        switch (letterRandom)
        {
            case 0:
                temp = "a";
                return temp;
            case 1:
                temp = "b";
                return temp;
            case 2:
                temp = "c";
                return temp;
            default:
                return temp;
        }
    }
    public string mobSpawn()
    {
        int rand = Random.Range(0, 3);
        string type = "berserker";
        switch (letterRandom)
        {
            case 0:
                type = "berserker";
                return type;
            case 1:
                type = "alch";
                return type;
            case 2:
                type = "flame";
                return type;
            case 3:
                type = "lava";
                return type;
            default:
                return type;
        }
    }
}



public class NodeList{

    
    public static int lenght = 16;
    public int branchNum = 0;

    public ArrayList coordinates = new ArrayList();

    Node[] mainList = null;

    public NodeList() {
        mainList = new Node[lenght];
        generateMap();
        
        for (int i = 0; i < mainList.Length; i++) {
            coordinates.Add(mainList[i].pos);
        }
        
        
    }
    

    


    public void generateMap() {

       

        for (int i = 0; i < lenght; i++) {
            mainList[i] = new Node();
            
        }

        for (int i = 0; i < lenght; i++) {
             if (i != lenght - 1)   //last
                 mainList[i].next = mainList[i + 1];
             else
                 mainList[i].next = null;
             if (i != 0)  //first
                 mainList[i].previous = mainList[i - 1];
             else
                 mainList[i].previous = null;

         }

        mainList[0].matrixAssignerStart();
        for (int i = 1; i < lenght; i++) {
            mainList[i].matrixAssigner();
            mainList[i].fixNodePos();

            
        }

      

        for (int i = 0; i < lenght; i++) {
          //  mainList[i].printNodePos();
          //  mainList[i].printNode();
            mainList[i].instantiateMap();
        }



    }



}


