using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    private Transform  playerTransform;
    public float offset;
    private void Start(){
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 temp=transform.position;
        temp.x=playerTransform.position.x;
        temp.y=playerTransform.position.y;
        temp.x+=offset;
        temp.x+=offset;
        transform.position=temp;
    }
}
