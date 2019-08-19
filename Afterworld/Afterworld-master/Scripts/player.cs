using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour {
    Rigidbody2D playerBody;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Animator playerAnime;
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject bulletBill;
    [SerializeField] GameObject gunHolder;
    [SerializeField] GameObject enemybullet;
    [SerializeField] float speedCap;


    AudioSource sound;
    bool runForward = false;
    bool runBackward = false;
    bool jump = false;
    bool facingPosition;
    BoxCollider2D myFeet;
    Transform playerModel;
    
   
    public int Health=1;//HEALTH

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject==enemybullet|| gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Enemy")))
        Health--;
    }



    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        playerBody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        playerAnime = GetComponent<Animator>();
        playerModel = GetComponent<Transform>();
        facingPosition = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Health<=0)//Death
        {
            
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            
            SceneManager.LoadScene(currentIndex);

            Health = 1;
        }
       
        float runControl= CrossPlatformInputManager.GetAxis("Horizontal");
        bool jumpControl = CrossPlatformInputManager.GetButtonDown("Jump");
        if (runControl == 1f)
        {
            runForward = true;
            facingPosition = true;
        }
        else if (runControl == -1f)
        {
            
            runBackward = true;
            facingPosition = false;
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            StartCoroutine(shoot());
            
        }


        Debug.Log(jumpControl);

        if (jumpControl && myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            jump = jumpControl;
        }


       
        
        
        
    }

    void FixedUpdate()
    {
        run();
        jumpCommand();
        
    }

    void run()
    {

        

        if (runForward) 
        {
     
            
            Vector2 playMove;
            if (playerBody.velocity.x < speedCap)
            {
                playMove = new Vector2(playerBody.velocity.x + speed, playerBody.velocity.y);
            }
            else
            {
                playMove = new Vector2(speedCap, playerBody.velocity.y);
            }
            playerModel.localScale = new Vector2(1f, 1f);
            gunHolder.transform.localScale = new Vector2(1f, 1f);
            playerBody.velocity = playMove;
            runForward = false;
            playerAnime.SetBool("Running", true);
        }
        else if(runBackward)
        {
            var playerSpeed = playerBody.velocity.x < 0 ? playerBody.velocity.x : 0;
            Vector2 playMove;
            if (Mathf.Abs(playerSpeed) < speedCap)
            {
                 playMove = new Vector2(playerSpeed - speed, playerBody.velocity.y);
            }
            else
            {
                playMove = new Vector2(-speedCap, playerBody.velocity.y);
            }
            playerModel.localScale = new Vector2(-1f,1f);
            gunHolder.transform.localScale = new Vector2(-1f, 1f);
            playerBody.velocity = playMove;
            runBackward = false;
            playerAnime.SetBool("Running", true);
        }
        else
        {
            playerBody.velocity *= .9f;
            playerAnime.SetBool("Running", false);

        }
        


    }

    void jumpCommand()
    {
        if (jump)
        {
            Vector2 jumpForce = new Vector2(0f, jumpSpeed);
            playerBody.velocity += jumpForce;
            jump = false;
        }
    }

    

    IEnumerator shoot()
    {
        playerAnime.SetBool("Shooting", true);
        yield return new WaitForSecondsRealtime(.1f);
        sound.Play();
        GameObject instance = Instantiate(bulletBill, gunHolder.transform.position, gunHolder.transform.rotation) ;
        instance.GetComponent<Rigidbody2D>().AddForce(transform.right * (gameObject.transform.localScale.x * 800f));
        playerAnime.SetBool("Shooting", false);

    }

    
    

    
}
