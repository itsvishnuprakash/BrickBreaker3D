using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //references
    Rigidbody playerRB;
    [SerializeField] private AudioSource specialEffects;
    [SerializeField] private BallMovement ballScript;
    //variables
    public float moveSpeed=5f;
    float horizontal;
    Vector3 playerMovement;
    

    private void Start() 
    {
        playerRB=GetComponent<Rigidbody>();
    }
    
    

    
    void Update()
    {
        horizontal=Input.GetAxisRaw("Horizontal");
        playerMovement=new Vector3(horizontal,0f,0f);
        transform.Translate(playerMovement*moveSpeed*Time.deltaTime);
        //transform.position=new Vector2(Mathf.Clamp(transform.position.x,-7.66f,7.71f),transform.position.y);
        playerRB.velocity=new Vector3(0f,0f,0f);

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Bolt"))
        {
            moveSpeed++;
            specialEffects.Play();
        }
        if(other.gameObject.CompareTag("Heart"))
        {
            ballScript.IncrementLife();
            specialEffects.Play();
        }
    }
}
