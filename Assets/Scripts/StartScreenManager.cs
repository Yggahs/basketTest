﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void startGame(){
        Application.LoadLevel(1);
    }
    public void closeGame(){
        Application.Quit();
    }
}
