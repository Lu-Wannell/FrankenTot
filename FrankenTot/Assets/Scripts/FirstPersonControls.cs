using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class FirstPersonControls : MonoBehaviour
{

    private Controls controls;
    public Controls.PlayerActions playerActions;

    [SerializeField]
    private PlayerUI playerUI;

    [Header("MOVEMENT SETTINGS")]
    [Space(7)]
    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed; // Speed at which the player moves
    public float lookSpeed; // Sensitivity of the camera movement
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.0f; // Height of the jump
    public Transform playerCamera; // Reference to the player's camera
                                   // Private variables to store input values and the character controller
    private Vector2 moveInput; // Stores the movement input from the player
    private Vector2 lookInput; // Stores the look input from the player
    private float verticalLookRotation = 0f; // Keeps track of vertical camera rotation for clamping
    private Vector3 velocity; // Velocity of the player
    private CharacterController characterController; // Reference to the CharacterController component

   /* [Header("SHOOTING SETTINGS")]
    [Space(7)]
    public GameObject projectilePrefab; // Projectile prefab for shooting
    public Transform firePoint; // Point from which the projectile is fired
    public float projectileSpeed = 20f; // Speed at which the projectile is fired*/
   

    [Header("PICKING UP SETTINGS")]
    [Space(7)]
    public Transform holdPosition; // Position where the picked-up object will be held
    public float pickUpRange = 3f; // Range within which objects can be picked up
    public GameObject heldObject; // Reference to the currently held object
    private bool holdingGun = false;


    [Header("CROUCH SETTINGS")]
    [Space(7)]
    public float crouchHeight = 1f; //make short
    public float standingHeight = 2f; //make normal
    public float crouchSpeed = 2.5f; //speed when crouching
    private bool isCrouching = false; // check if player is crouching
    private bool CanUncrouch = false; // Checks if player can Uncrouch
    public float crouchCheck = 1f; // Range above head needed to Uncrouch
    public Transform player; // Player's transform


    [Header("SPRINT SETTINGSS")]
    [Space(7)]
    public float sprintSpeed = 7.5f; //speed when crouching
    private bool isSprinting = false; // check if player is sprinting

    [Header("INSPECT SETTINGS")]
    [Space(7)]
    public bool isInspecting = false;
    public Transform inspectPosition;

    [Header("ROTATION SETTINGS")]
    [Space(7)]
    private Vector2 rotateInput; //Stores the Rotation Input from the player
    private bool rotateAllowed;
    [SerializeField]
    private float rotationSpeed = 1f;//Speed of rotation

    [Header("GRAB SETTINGS")]
    [Space(7)]
    public Transform grabPosition; // Position where the picked-up object will be held
    public float grabRange = 3f; // Range within which objects can be picked up
    public GameObject grabbedObject; // Reference to the currently held object
    public bool isGrabbing; //checks if player is grabbing
    public float grabJumpHeight = 1f; // Jump Height while grabbing
    private float grabSpeed;//Speed while grabbing
    public float grabSpeedModifier = 3f; //Modifier of movespeed when Grabbing

    [Header("Flashlight SETTINGS")]
    [Space(7)]
    public bool isFlashlightOn = false;
    public GameObject flashlight;
    public Light myLight;
    [SerializeField]
    private float lightIntensity;
    [SerializeField]
    private float InspectIntensity;

    [Header("Pause SETTINGS")]
    [Space(7)]
    public bool isPaused;

    // [Header("UI Settings")]
    // [space(7)]
    // public TMPro Prompttext;


    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();

        // Create a new instance of the input actions
        controls = new Controls();
        playerActions = controls.Player;

        // Start with Flashlight being off
        myLight = flashlight.GetComponent<Light>();
        myLight.intensity = 0;
    }

    private void OnEnable()
    {
       

        // Enable the input actions
        controls.Player.Enable();
        controls.Player.RotateObject.Disable(); //Disables Rotating Objects when not in Inspect Mode
        controls.Player.Inspect.Disable(); //player can't Enter Inspect mode at the beginning of the game as they aren't holding an object
        controls.Player.FlashLight.Disable(); // Player can't Use Flashlight until they have picked up the flashlight


        // Subscribe to the movement input events
        controls.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        controls.Player.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        controls.Player.LookAround.performed += ctx => lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        controls.Player.LookAround.canceled += ctx => lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        // Subscribe to the jump input event
        controls.Player.Jump.performed += ctx => Jump(); // Call the Jump method when jump input is performed

        // Subscribe to the shoot input event
        //controls.Player.Shoot.performed += ctx => Shoot(); // Call the Shoot method when shoot input is performed

        // Subscribe to the pick-up input event
        controls.Player.PickUp.performed += ctx => PickUpObject(); // Call the PickUpObject method when pick-up input is performed

        // Subscribe to the crouch input event
        controls.Player.Crouch.performed += ctx => ToggleCrouch(); // Call the Crouch method when crouch input is performed

        // Subscribe to the sprint input event
        controls.Player.Sprint.performed += ctx => StartSprint(); // Call the Sprint method when sprint input is performed
        controls.Player.Sprint.canceled += ctx => EndSprint(); // End Sprint Input when sprint input is canceled

        // Subscribe to the Inspect Input
        controls.Player.Inspect.performed += ctx => ToggleInspect(); // Call the Inspect method when inspect input is performed


        // Subscribe to the Rotate Input
        controls.Player.RotateObjectPressed.performed += ctx => { rotateAllowed = true; }; // Call the RotateObject method when rotate input is performed
        controls.Player.RotateObjectPressed.canceled += ctx => { rotateAllowed = false; }; // Sets it so rotating is not allowed when not performing rotate action

        controls.Player.RotateObject.performed += ctx => rotateInput = ctx.ReadValue<Vector2>(); // Update rotate Input when rotate input is performed
        controls.Player.RotateObject.canceled += ctx => rotateInput = Vector2.zero; // Reset rotateInput when rotate input is canceled


        // Subscribe to the Grab Input

        controls.Player.GrabObject.performed += ctx => GrabObject()  ; // Call the GrabObject method when grab input is performed
        controls.Player.GrabObject.canceled += ctx => DropObject(); // Call the DropObject method when drop input is performed

        //subscribe to flashlight Input
        controls.Player.FlashLight.performed += ctx => ToggleFlashlight();

        //Subscribe to pause Input
        controls.Player.PauseMenubutton.performed += ctx => TogglePause();
    }

    private void Update()
    {
        // Call Move and LookAround methods every frame to handle player movement and camera rotation
        Move();
        LookAround();
        ApplyGravity();

        if (rotateAllowed)     
        {
            RotateObject();
        }

        if(isGrabbing)
        {
            
        }
    }

    public void Move()
    {
        // Create a movement vector based on the input
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // Transform direction from local to world space
        move = transform.TransformDirection(move);

        //players speed is dependant on actions they may be performing
        float currentSpeed;
        if (isGrabbing)
        {
            grabSpeed = moveSpeed - grabSpeedModifier;
            currentSpeed = grabSpeed;
        }
        else if (isCrouching)
        {
            currentSpeed = crouchSpeed;
            playerUI.UpdateFStateCrouch();
        }
        else if(isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
            playerUI.UpdateFStateStand();
        }

        // Move the character controller based on the movement vector and speed
        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    public void LookAround()
    {
        // Get horizontal and vertical look inputs and adjust based on sensitivity
        float LookX = lookInput.x * lookSpeed;
        float LookY = lookInput.y * lookSpeed;

        // Horizontal rotation: Rotate the player object around the y-axis
        transform.Rotate(0, LookX, 0);

        if(isGrabbing)
        {
            // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping
            verticalLookRotation -= LookY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60f, 60f);
        }
        else
        {
            // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping
            verticalLookRotation -= LookY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        }
       

        // Apply the clamped vertical rotation to the player camera
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f; // Small value to keep the player grounded
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the velocity
        characterController.Move(velocity * Time.deltaTime); // Apply the velocity to the character
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            if ((isGrabbing))
            {
                
                velocity.y = Mathf.Sqrt(grabJumpHeight * -2f * gravity);
            }
            else
            {
                // Calculate the jump velocity
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
           
        }
    }

    /*public void Shoot()
    {
        if (holdingGun == true)
        {
            // Instantiate the projectile at the fire point
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Get the Rigidbody component of the projectile and set its velocity
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * projectileSpeed;

            // Destroy the projectile after 3 seconds
            Destroy(projectile, 3f);
        }
    }*/

    public void PickUpObject()
    {
        // Check if we are already holding an object
        //Drops object if holding object
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
           // heldObject.transform.position = player.position;
            heldObject.transform.parent = null;
            //holdingGun = false;
            heldObject = null;
            controls.Player.Inspect.Disable(); // Disables Inspect action as the player can't Inspect when not holding an Object.
            playerUI.PutDownObjectUI();//Sets UI to not show holding UI
            return;
        }

        // Perform a raycast from the camera's position forward
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        // Debugging: Draw the ray in the Scene view
        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 2f);


        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            // Check if the hit object has the tag "PickUp"
            if (hit.collider.CompareTag("PickUp"))
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                Debug.Log(heldObject.name);
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                //heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;
                playerUI.PickUpObjectUI();//Sets UI to Holding ObjectUI
            }
            /*else if (hit.collider.CompareTag("Gun"))
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

                holdingGun = true;
            }*/
            else if (hit.collider.CompareTag("Flashlight"))
            {
               Destroy(hit.collider.gameObject);
                controls.Player.FlashLight.Enable();
                playerUI.hasFlashlight = true;  
            }
            Debug.Log(heldObject.name);
            controls.Player.Inspect.Enable(); //Player can now Inspect a held Object
        }
    }

    public void ToggleCrouch()
    {
        Ray ray = new Ray(player.position, player.up);
        RaycastHit hit;

        // Debugging: Draw the ray in the Scene view
        Debug.DrawRay(player.position, player.up * crouchCheck, Color.green, 2f);


        if (Physics.Raycast(ray, out hit, crouchCheck))// Checks if an object is above player
        {
            CanUncrouch = false;
        }
        else 
            CanUncrouch = true;

        if (isCrouching)
        {
            //if player is crouching it needs to do an Uncrouch check
            if (CanUncrouch)
            {
                characterController.height = standingHeight;
                isCrouching = false;
            }
            else
            { return; }
        }
        else
        {
            characterController.height = crouchHeight;
            isCrouching = true;
        }
    }

    // performed when the sprint button is pressed
    public void StartSprint()
    { 
      isSprinting = true;
    }

    //performed when sprint button is let go
    public void EndSprint()
    {
       isSprinting = false;
    }

    public void ToggleInspect()
    {
        if (isInspecting)
        {

            //Disable rotating
            controls.Player.RotateObject.Disable();

            // Enable all other input actions while in Inspect Mode
            controls.Player.Movement.Enable();
            controls.Player.LookAround.Enable();
            controls.Player.Sprint.Enable();
            controls.Player.Jump.Enable();
            controls.Player.Crouch.Enable();
            controls.Player.PickUp.Enable();
            controls.Player.Shoot.Enable();
            controls.Player.GrabObject.Enable();

            //Return Object to Holding Position
            heldObject.transform.position = holdPosition.position;
            //heldObject.transform.rotation = holdPosition.rotation;
            heldObject.transform.parent = holdPosition;

            //Disable Inspect UI and Enable Holding UI
            playerUI.ExitInspectUI();

            isInspecting = false;

        }
        else
        {

            //enable Rotating
            controls.Player.RotateObject.Enable();

            if (myLight.intensity != 0)
            { myLight.intensity = InspectIntensity; }

            // Disable all other input actions while in Inspect Mode
            controls.Player.Movement.Disable();
            controls.Player.LookAround.Disable();
            controls.Player.Sprint.Disable();
            controls.Player.Jump.Disable();
            controls.Player.Crouch.Disable();
            controls.Player.PickUp.Disable();
            controls.Player.Shoot.Disable();
            controls.Player.GrabObject.Disable();

            isInspecting = true;

            //Move Object to Inspect Position
            heldObject.transform.position = inspectPosition.position;
           // heldObject.transform.rotation = inspectPosition.rotation;
            heldObject.transform.parent = inspectPosition;

            //Enable Inspect UI and Disable Holding UI
            playerUI.EnterInspectUI();

        }
    }

   


    public void RotateObject()
    {
        
        rotateInput = rotateInput * rotationSpeed; //rotates the object based on rotation spped
        heldObject.transform.Rotate(playerCamera.up, rotateInput.x, Space.World);//allows for up and down rotation
        heldObject.transform.Rotate(-playerCamera.right, rotateInput.y, Space.World); // allows for left and right rotation
 
    }


    //Parts of the Grab code were Influenced by
    // Title: Drag and Drop with New Input system! ( Touch and Mouse )
    // Author: Game Dev Geeks
    // Date: 9 September 2024
    // Code Version: 1.0
    // Availability: www.youtube.com/watch?v=zo1dkYfIJVg&t=2s


    public void GrabObject()
    { 

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        // Debugging: Draw the ray in the Scene view
        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.yellow, 2f);

        
        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                grabbedObject = hit.collider.gameObject;
                Debug.Log(grabbedObject.name);
                //grabbedObject.GetComponent<Rigidbody>().useGravity = false; 
                grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                // Attach the object to the hold position
                grabPosition.position = grabbedObject.transform.position;
                grabPosition.rotation = grabbedObject.transform.rotation;
                grabbedObject.transform.parent = grabPosition;
                isGrabbing = true;
            }
            
        }
    }

    public void DropObject()
    {
        //grabbedObject.GetComponent<Rigidbody>().useGravity = true; 
        grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        grabbedObject.transform.parent = null;
        grabbedObject = null;
        isGrabbing = false;
    }

    public void ToggleFlashlight()
    {
        if (isFlashlightOn) 
        {
            myLight.intensity = 0;
            isFlashlightOn = false;
        }
        else
        {
            if (isInspecting)
            {
                myLight.intensity = InspectIntensity;
            }
            else
            {
                myLight.intensity = lightIntensity;
            }
            isFlashlightOn = true;
        }
    }

     public void TogglePause()
     {
         if (isPaused)
         {
             playerUI.UnpauseGame();

             // Enable all other input actions while in Inspect Mode
             controls.Player.Movement.Enable();
             controls.Player.LookAround.Enable();
             controls.Player.Sprint.Enable();
             controls.Player.Jump.Enable();
             controls.Player.Crouch.Enable();
             controls.Player.PickUp.Enable();
             controls.Player.GrabObject.Enable();
             if( heldObject != null)
             {
                controls.Player.Inspect.Enable();
             }
             if(isInspecting)
             {
                controls.Player.Inspect.Enable();
                controls.Player.RotateObject.Enable();
            }
             if(playerUI.hasFlashlight == true)
             {
                controls.Player.FlashLight.Enable();
             }
                

             isPaused = false;

             

         }
         else
         {

             playerUI.PauseGame();

             // Disable all other input actions while paused
             controls.Player.Movement.Disable();
             controls.Player.LookAround.Disable();
             controls.Player.Sprint.Disable();
             controls.Player.Jump.Disable();
             controls.Player.Crouch.Disable();
             controls.Player.PickUp.Disable();
             controls.Player.GrabObject.Disable();
             controls.Player.RotateObject.Disable();
             controls.Player.FlashLight.Disable();
             controls.Player.Inspect.Disable();

            isPaused = true;

             

         }
     }

}
