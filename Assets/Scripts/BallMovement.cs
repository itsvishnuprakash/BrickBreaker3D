using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    
    //references
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject instructions;
    [SerializeField]private TMP_Text livesText;
    [SerializeField]private TMP_Text gameOverText;
    
    [SerializeField]private GameObject panel;
    [SerializeField]private GameObject playBtn;
    Rigidbody rb;
    
    //variables
    public float speed=5f;
    public int totalBlocks=1;
    float x,y;
    float z=0f;
    Vector3 initialPosition;
    bool isStart=false;
    int lives;
    int blockesDestroyed;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        gameOverText.gameObject.SetActive(false);
        playBtn.SetActive(true);
        panel.SetActive(false);
        
        x=speed;
        y=speed;
        initialPosition=transform.position;
        lives=3;
        totalBlocks++;
        blockesDestroyed=0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isStart)
        {
            transform.position=new Vector3(player.transform.position.x,initialPosition.y,initialPosition.z);
        }
        else
        {
            rb.velocity=new Vector3(x,y,z);
        }
        if (Input.GetKeyDown("space"))
        {
            isStart=true;
            instructions.SetActive(false);
        }
        
        livesText.text="Lives "+lives;

        if(lives==0 || blockesDestroyed==totalBlocks)
        {
            GameOver();
        }

    }

    void Restart()
    {
        transform.position=initialPosition;
        x=speed;
        y=speed;
        isStart=false;
    }
    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        playBtn.SetActive(false);
        if(lives<=0)
        {
            gameOverText.text="You Lose..";
        }
        else
        {
            gameOverText.text="You Win!!";
        }
        x=0;
        y=0;
        panel.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Top"))
        {
            y=-y;
        }
        else if(other.gameObject.CompareTag("Right") || other.gameObject.CompareTag("Left"))
        {
            x=-x;
        }
        if(other.gameObject.CompareTag("Brick"))
        {
            blockesDestroyed++;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Respawn"))
        {
            
            Restart();
            lives-=1;
        }
    }

    public void PauseGame()
    {
        Time.timeScale=0;
        panel.SetActive(true);
    }
    public void PlayGame()
    {
        Time.timeScale=1;
        panel.SetActive(false);
    }
    public void ReplayGame()
    {
        Time.timeScale=1;
        panel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void IncrementLife()
    {
        lives+=1;
    }
}
