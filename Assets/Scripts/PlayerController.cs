using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public Animator animator;
    public float speed;
    public float Jump;
    private Rigidbody2D rbd;
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
