using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public int[,] borad = new int[4,4];
    private int currentPlayer = 1;
    Manager gameManager;
    Rect middleRect = new Rect(Screen.width/2 - 150, Screen.height/2 - 150, Screen.width/2 + 150, Screen.height/2 + 300);

    void Start() {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++)
            {
                borad[i, j] = 0;
            }
        }
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void OnGUI() 
    {
        GUI.BeginGroup(middleRect);
            #region nine button
            if (GUI.Button(new Rect(0,0,100,100),"1"))
            {
                if (borad[0, 0] == 0)
                {
                    borad[0, 0] = currentPlayer;
                    gameManager.OnSelectOnZone(0, 0, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(100, 0, 100, 100), "2"))
            {
                if (borad[0, 1] == 0)
                {
                    borad[0, 1] = currentPlayer;
                    gameManager.OnSelectOnZone(0, 1, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(200, 0, 100, 100), "3"))
            {
                if (borad[0, 2] == 0)
                {
                    borad[0, 2] = currentPlayer;
                    gameManager.OnSelectOnZone(0, 2, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(0, 100, 100, 100), "4"))
            {
                if (borad[1, 0] == 0)
                {
                    borad[1, 0] = currentPlayer;
                    gameManager.OnSelectOnZone(1, 0, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(100, 100, 100, 100), "5"))
            {
                if (borad[1, 1] == 0)
                {
                    borad[1, 1] = currentPlayer;
                    gameManager.OnSelectOnZone(1, 1, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(200, 100, 100, 100), "6"))
            {
                if (borad[1, 2] == 0)
                {
                    borad[1, 2] = currentPlayer;
                    gameManager.OnSelectOnZone(1, 2, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(0, 200, 100, 100), "7"))
            {
                if (borad[2, 0] == 0)
                {
                    borad[2, 0] = currentPlayer;
                    gameManager.OnSelectOnZone(2, 0, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(100, 200, 100, 100), "8"))
            {
                if (borad[2, 1] == 0)
                {
                    borad[2, 1] = currentPlayer;
                    gameManager.OnSelectOnZone(2, 1, currentPlayer);
                    CheckBoard();
                }
            }
            if (GUI.Button(new Rect(200, 200, 100, 100), "9"))
            {
                if (borad[2, 2] == 0)
                {
                    borad[2, 2] = currentPlayer;
                    gameManager.OnSelectOnZone(2, 2, currentPlayer);
                    CheckBoard();
                }
            }
            #endregion
       GUI.EndGroup();
    }

    void CheckBoard() 
    {
        for (int i = 0; i < 3; i++)
        {
            borad[i, 3] = borad[i, 0] + borad[i, 1] + borad[i, 2];
            if (borad[i, 3] == 3)
            {
                gameManager.OnWin("√");
            }
            else if (borad[i, 3] == -3)
            {
                gameManager.OnWin("○");
            }
        }
        for (int i = 0; i < 3; i++) 
        {
            borad[3, i] = borad[0,i] + borad[1,i] + borad[2,i];
            if (borad[3, i] == 3)
            {
                gameManager.OnWin("√");
                //GUI.Label(tittleRect, "√ WIN!!!!");
            }
            else if (borad[3, i] == -3) 
            {
                gameManager.OnWin("○");
                //GUI.Label(tittleRect, "○ Win!!!!!");
            }
        }
        borad[0, 3] = borad[0, 2] + borad[1, 1] + borad[2, 0];
        if (borad[0, 3] == 3)
        {
            gameManager.OnWin("√");
            //GUI.Label(tittleRect, "√ WIN!!!!");
        }
        else if (borad[0, 3] == -3)
        {
            gameManager.OnWin("○");
            //GUI.Label(tittleRect, "○ Win!!!!!");
        }
        borad[3, 3] = borad[0, 0] + borad[1, 1] + borad[2, 2];
        if (borad[3, 3] == 3)
        {
            gameManager.OnWin("√");
           // GUI.Label(tittleRect, "√ WIN!!!!");
        }
        else if (borad[3, 3] == -3)
        {
            gameManager.OnWin("○");
            //GUI.Label(tittleRect, "○ Win!!!!!");
        }
        currentPlayer = -currentPlayer;
    }
}
