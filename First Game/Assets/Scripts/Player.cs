using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private bool leftGround = true;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    // private int jumpCount = 0;
    public int availableJumps = 0;
    private int superJumpsRemaining;
    public static int score = 0;
    public int speedTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    private void jump() {
        if (availableJumps > 0) // this is to make sure we can jump and jump extra when jump powerup is collected.
        {
            availableJumps--;
            float jumpPower = 5.7f;
            if (superJumpsRemaining > 0) {
                jumpPower *= 1.6f;
                superJumpsRemaining--;
            }
            rigidbodyComponent.velocity=Vector3.zero;
            // jumpCount += 1;
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
            // jump();
        }



        horizontalInput = Input.GetAxis("Horizontal");
    }
    //fixedUpdate is called once every physics update, (100 times per second)

    private void FixedUpdate() 
    {
        if (speedTime > 0) // THIS IS NOT HOW TO DO IT, but works for now
        {   
            speedTime--;  // reduces speedTime untill 0 then goes to else.
            rigidbodyComponent.velocity = new Vector3(horizontalInput * 6, rigidbodyComponent.velocity.y, 0); 
        } else
        {
            rigidbodyComponent.velocity = new Vector3(horizontalInput * 3, rigidbodyComponent.velocity.y, 0);
        }
        if (jumpKeyWasPressed) {
            jump();
            jumpKeyWasPressed = false;
            leftGround = true;
        }
        else if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 1) { // on ground
            if (leftGround)
            {
                availableJumps++;
            }
            leftGround = false;
        }
    }

    private void OnTriggerEnter(Collider other) { // when it triggers with another object it will check what tag the other object had and act accordingly.
        if (other.CompareTag("Coin")) { 
            Destroy(other.gameObject);//destroys the powerup
            score++;
        }
        if (other.CompareTag("JumpBoost")) { 
            
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
        if (other.CompareTag("ExtraJump")) { 
            Destroy(other.gameObject);
            availableJumps++;
        }
        if (other.CompareTag("SpeedBoost")) { 
            // other.ParticleSystem.Play();

            Destroy(other.gameObject);
            speedTime = 180; //will enable if statment on line 61 which will increase speed and reduce speedTime
        }
        if (other.CompareTag("Spikes")) {  
            // Debug.Log("AJAJAJOJ");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // simply restarts the scene because dead by spike.
        }
    }




    
}
