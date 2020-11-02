using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    public Animator animator;
    public  float speed;
    private Rigidbody2D rbd;
    public  KeyController KeyController;
    public ScoreController scorecontroller;
    public EnemyController enemycontroller;
    public GameoverController gameovercontroller;
    public GameObject[] Heart;
    int lifeLeft=1;
    Vector2 checkpoint=new Vector2(0f,0f);
    private float restartPosition=-17.0f;
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
        scorecontroller.Increase(10);
    }
    public void KillPlayer(){
        if(lifeLeft >= 0)
        {
            Heart[lifeLeft--].SetActive(false);
            gameObject.transform.position = checkpoint;
        }
        else
        {
           gameovercontroller.PlayerDie();
            this.enabled = false;
        }   
    }
    private void Awake() {
        rbd=gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update() {   
    float horizontal=Input.GetAxisRaw("Horizontal");
    float vertical=Input.GetAxisRaw("Jump");

     PlayerMovementAnimation(horizontal,vertical);
     MoveCharacter(horizontal,vertical);
     restartposition(restartPosition);
    }
    private void MoveCharacter(float horizontal,float vertical){

      Vector3 position=transform.position;
      position.x +=horizontal*speed*Time.deltaTime;
      transform.position=position;

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
      void restartposition( float restartPosition){
         if(gameObject.transform.position.y<restartPosition){
             if(lifeLeft>=0){
                 Heart[lifeLeft--].SetActive(false);
                 gameObject.transform.position=checkpoint;
             }
             else{
                 gameovercontroller.PlayerDie();
                 this.enabled=false;
             }
         }
     }
}

