using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject borad;
    public GameObject message;
    private GameObject _board;
    private GameObject _message;

    void Start() {
        _board = Instantiate(borad);
        _message = Instantiate(message);
    }

    public void OnSelectOnZone(int x, int y, int symbol) 
    {
        if (symbol == 1) _message.GetComponent<Message>().OnChangeBox(x, y, "√");
        else _message.GetComponent<Message>().OnChangeBox(x, y, "○");
    }

    public void OnWin(string name)
    {
        _message.GetComponent<Message>().OnChangeWinnerMessage(name + " Win this game!!!!");
    }

    public void OnReStart() {
        Destroy(_board);
        Destroy(_message);
        _board = Instantiate(borad);
        _message = Instantiate(message);
    }
}
