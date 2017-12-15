using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Animator anim;
    public bool isWall = false;
    public float walkSpeed = 0.03f;
    public int lifePoints = 10;
    public float runSpeed = 0.09f;
    private float tempSpeed;
    public AudioSource myaudio;
    public AudioClip clip1;

    void OnTriggerEnter (Collider c) {

    }
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator> ();
        tempSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update () {

        float horizontalMove = Input.GetAxis ("Horizontal") * 1.5f;
        float verticalMove = Input.GetAxis ("Vertical") * walkSpeed;
        float x = Input.GetAxis ("Vertical");
        transform.Translate (0, 0, verticalMove);
        float y = Input.GetAxis ("Horizontal");
        transform.Rotate (0, horizontalMove, 0);

        if (verticalMove != 0) {
            if (!isWall) {
                // anim.SetTrigger ("walking");
                anim.SetBool ("walking", true);

            } else if (isWall) {

            }
        } else if (Input.GetButtonUp ("Vertical") || verticalMove == 0) {
            anim.SetTrigger ("idle");
            anim.SetBool ("walking", false);

        }

        if (Input.GetKeyDown (KeyCode.LeftShift)) {
            walkSpeed = runSpeed;
            anim.SetBool ("isRunning", true);
        }

        if (Input.GetKeyUp (KeyCode.LeftShift)) {
            walkSpeed = tempSpeed;
            anim.SetBool ("isRunning", false);
        }

        if (Input.GetButtonDown ("Jump")) {
            anim.Play ("jump", -1, 0f);
        }
        if (lifePoints == 0) {
            anim.Play ("dying");
            // anim.SetBool ("isDead", true);
            
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            anim.SetBool ("isAttacking", true);
        }
         if (Input.GetKeyUp(KeyCode.E)) {
            anim.SetBool ("isAttacking", false);
        }
        if(Input.GetKeyDown(KeyCode.T)){
            anim.SetBool ("wallRun", true);
            
        }
        if(Input.GetKeyUp(KeyCode.T)){
            anim.SetBool ("wallRun", false);
            
        }
    }
}