using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour {

    string winnerMessage;
    string currentPlayer ="√";
    private string[,] box = new string[3, 3];

    void Start() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) { 
                box[i,j] = "empty";
            }
        }
    }

    void OnGUI() 
    {
        GUI.Label(new Rect(260, 400, 120, 20), winnerMessage);
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) { 
                GUI.Label(new Rect(50*j, 50*i, 50, 50), box[i,j]);
            }
        }
        GUI.Label(new Rect(260, 50, 120, 20), "Current Player is :" + currentPlayer);
    }

    public void OnChangeWinnerMessage(string newMessage) 
    {
        winnerMessage = newMessage;
    }

    public void OnChangeBox(int i, int j, string symbol) 
    {
        box[i, j] = symbol;
        if (symbol == "√") currentPlayer = "○";
        else currentPlayer = "√";
    }
}
