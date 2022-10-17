using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public  CharacterController controller;// variable containing the controll componenet in player
    public  Vector3 direction; //variable controlling direction of player movement
    public float forwardspeed; // speed of player
    private int desiredlane = 1; // 0 is left, 1 is middle, 2 is right, the lane that the player will be in
    public  float lanedistance; //the distance between each lane
    public  float JumpForce;//how high jump
    public float gravity = -20;//how strong gravity
    public Animator animator;
    public LayerMask groundlayer; 
    public Transform groundcheck;
    public bool isGrounded;
    public float maxspeed;
   

    
    // Start is called before the first frame update
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if(!PlayerManager.isGameStarted)
           return;

       if(PlayerManager.isGameStarted)
        {
            if(forwardspeed < maxspeed)
            {
            forwardspeed += 0.1f * Time.deltaTime;
            }
        }
          
       
       animator.SetBool("IsGameStarted", true);
       
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredlane++;
            if(desiredlane == 3)
            {
                desiredlane = 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
             desiredlane--;
            if (desiredlane == -1)//if desired lane = -1 then the code will change it back to 0
            {
                desiredlane = 0;
            }
        }





        if(SwipeManager.swipeRight)
        {
            desiredlane++;
            if(desiredlane == 3)
            {
                desiredlane = 2;
            }
        }
        
        if (SwipeManager.swipeLeft)//when left arrow is bressed desired lane will decrease by 1
        {
            desiredlane--;
            if (desiredlane == -1)//if desired lane = -1 then the code will change it back to 0
            {
                desiredlane = 0;
            }
           
        }
       
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        //created a new vector3 called targetposition which will calculate the position the player need to be in the future.
        //the computer will find the position.z and y, as well as forward and up. then it will check where that is and set targetpositon variable into that spot.
        if(desiredlane == 0)
        {
            targetPosition += Vector3.left * lanedistance;// if the desired lane in the end is 0 then the targetposition will be changed to the left
        }else if(desiredlane == 2)
        {
            targetPosition += Vector3.right * lanedistance;//if the disired lane is = 2 then the targetpositon will be moved to the left
        }
        

        transform.position = Vector3.Lerp(transform.position, targetPosition, 20 * Time.deltaTime);
        //setting the position of the player(transform.position) equal to the targetpositon(through a vector3). so whenever the targetpositon variable gets changed the player will also change positon with it.
        //the Vector.Lerp function makes the transition between lanes smooth. if the flaot at the end is low it will transition slowly. if it is high it will transition fast
        controller.center = controller.center;
        //before this code^ the code obove it would cause a bug and the player would pass right through the cones. but this code fixes that problom

        direction.z = forwardspeed;
        //useing the forwardspeed variable we are assigning the "direction" to the z axis making the z line the forward direction and the deffualt dirrecttion.


        direction.y += gravity * Time.deltaTime;//this code combines the direction.y/jumpforce with the gravity so that the player will go down.*time.deltatime makes it go up and down smoothly.
        if (controller.isGrounded)// this says that when the player is on the ground only then can we jump
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Jump());
            }

            if (SwipeManager.swipeUp)
            {
               StartCoroutine(Jump());
            }
            
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slide());
        }
        if(SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
            
        }

        
    }


    private void FixedUpdate()
    {
         if(!PlayerManager.isGameStarted)
           return;
        controller.Move(direction* Time.fixedDeltaTime);// telling player to move in direction * time.deltatime( whcih makes the player go by frames and make it smoother)
    }
    //jumping function
    public  IEnumerator Jump()
    {
        controller.center = new Vector3(0,1.3f,0);
        animator.Play("Jump");
        direction.y = JumpForce;//setting the jumpforce to the y direction. if jumpforce = 10 then y direction = 10
        yield return new WaitForSeconds(1.05f);
        controller.center = new Vector3(0,1f,0);
        animator.Play("Sprint");
    }
    //gameover trigger stuff
    private void OnControllerColliderHit(ControllerColliderHit hit)//controllercolliderhit hit perameter has the collision checking system biult in
    {
        if (hit.transform.tag == "Obsticle")//when the player triggers the hit system(when it collides with a gameobject with the tag of "obsticle") it will trigger the body of the function
        {
            PlayerManager.GameOver = true;//body of the function. changes the GameOver bool to true.
        }
    }
    //slideing function
    public IEnumerator Slide()
    {
        
        controller.center = new Vector3(0,0.5f,0);
        controller.height = 1;
        animator.SetBool("IsSliding", true);
        yield return new WaitForSeconds(1f);

        controller.center = new Vector3(0,1f,0);
        controller.height = 2;
        animator.SetBool("IsSliding",false);
    }
}
