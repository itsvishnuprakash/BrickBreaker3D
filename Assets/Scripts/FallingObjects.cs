using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public float fallingSpeed=3f;
    bool isFall=false;
    private void Update() 
    {
        if(isFall)
        {
            transform.Translate(new Vector3(0f,-1f,0f)*fallingSpeed*Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("GameController"))
        {
            isFall=true;
            print("isfall");
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
