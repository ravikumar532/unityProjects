using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     Debug.Log("collision:"+collision.gameObject.name);
    // }
    public Animator animator;
    public  float speed;
    private Rigidbody2D rbd;
    private BoxCollider2D box;
    public  KeyController KeyController;
    public ScoreController scorecontroller;
    public EnemyController enemycontroller;
    public GameoverController gameovercontroller;
    //varibles  for  grounding system
    public float jumpspeed;
    public LayerMask  groundelayer;
    public bool grounded=true;
    private void OnCollisionEnter2D(Collision2D collision){
        grounded=true;
    }
    private void  Isgrounded(){
        if(grounded==true)
        {
            rbd.velocity=new Vector3(rbd.velocity.x,jumpspeed);
            grounded=false;
        }
    }
    public void PickUpKey(){
        Debug.Log("Player Picked  Key");
        scorecontroller.Increase(10);
    }
    public void KillPlayer(){
        Debug.Log("Player killed by  the Enemy");
        gameovercontroller.PlayerDie();
        this.enabled=false;
    }
    private void Awake() {
        Debug.Log("Player  is  Awake");
        rbd=gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update() {   
    float horizontal=Input.GetAxisRaw("Horizontal");
    float vertical=Input.GetAxisRaw("Jump");
     PlayerMovementAnimation(horizontal,vertical);
     MoveCharacter(horizontal,vertical);
    }
    private void MoveCharacter(float horizontal,float vertical){
    // Move character horizontally
      Vector3 position=transform.position;
      position.x +=horizontal*speed*Time.deltaTime;
      transform.position=position;
    //move character vertical;
    if(vertical>0){
        Isgrounded();
    }
}
    private void  PlayerMovementAnimation(float horizontal,float vertical)
    {
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        Vector3 scale=transform.localScale;
        if(horizontal<0)
        {
            scale.x=-1f*Mathf.Abs(scale.x);
        }
        else if(horizontal>0){
            scale.x=Mathf.Abs(scale.x);
        }
        transform.localScale=scale;
        if(vertical>0){
            animator.SetBool("Jump",true);
        }else{
            animator.SetBool("Jump",false);
        }
     }

     
}

