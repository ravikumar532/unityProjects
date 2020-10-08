using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    public Animator animator;
    public float speed;
    public float Jump;
    private Rigidbody2D rbd;
    public ScoreController scorecontroller;
    public EnemyController enemycontroller;
    public void PickUpKey(){
        Debug.Log("Player Picked Up");
        scorecontroller.Increase(10);
    }
    public void KillPlayer(){
        Debug.Log("Player killed by the enemy");
        ReloadScene();
    }
    private void ReloadScene(){
        SceneManager.LoadScene(0);
    }
    private void  FixedUpdate() {
        rbd=gameObject.GetComponent<Rigidbody2D>();
    }
     private void Update() {
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical=Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);
    }
    private void MoveCharacter(float horizontal,float vertical){
        Vector3 position=transform.position;
        position.x+=horizontal * speed *Time.deltaTime;
        transform.position=position;
        if(vertical>0){
           rbd.velocity=new Vector2(rbd.velocity.x,Jump);
        }
    }
    private void PlayMovementAnimation(float horizontal,float vertical){
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        Vector3 scale=transform.localScale;
        if(horizontal<0){
              scale.x=-1f*Mathf.Abs(scale.x);        
        }else if(horizontal>0){
            scale.x=1f*Mathf.Abs(scale.x);
        } 
        transform.localScale=scale;
        if(vertical>0){
            animator.SetBool("Jump",true);
        }
        else{
            animator.SetBool("Jump",false);
        }
    }
}
