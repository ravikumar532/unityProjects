using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float rayDist;
    private bool movingRight;
    public Transform groundDetect;
    private void Update() {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
       RaycastHit2D groundCheck=Physics2D.Raycast(groundDetect.position,Vector2.down,rayDist);

        if(groundCheck.collider==false){
            SoundManager.Instance.Play(Sounds.EnemyStep);
            if(movingRight){
                transform.eulerAngles=new Vector3(0,-180,0);
                movingRight=false;
            }
            else{
                transform.eulerAngles=new Vector3(0,0,0);
                movingRight=true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
       if(collision.gameObject.GetComponent<PlayerController>()!=null){
           PlayerController playercontroller =collision.gameObject.GetComponent<PlayerController>();
           SoundManager.Instance.Play(Sounds.PlayerDeath);
           playercontroller.KillPlayer();
       }
   }
   
}
