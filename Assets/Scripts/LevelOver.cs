﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOver : MonoBehaviour
{
    private void  OnTriggerEnter2D(Collider2D collision) {
         if(collision.gameObject.GetComponent<PlayerController>()!=null){
             Debug.Log("Player Level  is Over");
         }
    }
}