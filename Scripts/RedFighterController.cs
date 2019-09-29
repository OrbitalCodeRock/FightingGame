using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFighterController : MonoBehaviour {
    private GameObject player;
    private Rigidbody2D playerBody;

    private bool canJump;
    private bool isAttacking;
    private bool isCrouched;

	// Use this for initialization
	void Start () {
        player = this.gameObject;
        playerBody = player.GetComponent<Rigidbody2D>();
        canJump = true;
        isAttacking = false;
        isCrouched = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.tag.Equals("Player1")){
            if (Input.GetKey(KeyCode.D) && !isCrouched && !isAttacking)
            {
                if(canJump)player.GetComponent<Animator>().SetInteger("state", 1);
                player.transform.position = new Vector3(player.transform.position.x + 2.5f * Time.deltaTime, player.transform.position.y, player.transform.position.z);
            }
            else if (Input.GetKey(KeyCode.A) && !isCrouched && !isAttacking)
            {
                if(canJump)player.GetComponent<Animator>().SetInteger("state", 1);
                player.transform.position = new Vector3(player.transform.position.x - 2.5f * Time.deltaTime, player.transform.position.y, player.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.W) && canJump && !isAttacking)
            {
                player.GetComponent<Animator>().SetInteger("state", 3);
                playerBody.AddForce(new Vector2(0,500));
                canJump = false;
            }
            if ((Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) && canJump && !isCrouched)
            {
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
            if ((Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)) && canJump && !isCrouched)
            {
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
            if((Input.GetKeyDown(KeyCode.F)) && canJump && !isCrouched && !isAttacking)
            {
                player.GetComponent<Animator>().SetInteger("state", 5);
                isAttacking = true;
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                isAttacking = false;
                player.GetComponent<Animator>().SetInteger("state", 0);
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                isCrouched = true;
                player.GetComponent<BoxCollider2D>().size = new Vector2(9.429f, 24f);
                player.GetComponent<BoxCollider2D>().offset = new Vector2(-1.551f, 11.808f);
                player.GetComponent<Animator>().SetInteger("state", 4);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                isCrouched = false;
                player.GetComponent<BoxCollider2D>().size = new Vector2(9.429f, 30.197f);
                player.GetComponent<BoxCollider2D>().offset = new Vector2(-1.551f, 15.0198f);
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
        }
        else if (player.tag.Equals("Player2"))
        {
            if (Input.GetKey(KeyCode.RightArrow) && !isCrouched && !isAttacking)
            {
                if (canJump) player.GetComponent<Animator>().SetInteger("state", 1);
                player.transform.position = new Vector3(player.transform.position.x + 2.5f * Time.deltaTime, player.transform.position.y, player.transform.position.z);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !isCrouched && !isAttacking)
            {
                if (canJump) player.GetComponent<Animator>().SetInteger("state", 1);
                player.transform.position = new Vector3(player.transform.position.x - 2.5f * Time.deltaTime, player.transform.position.y, player.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && canJump && !isAttacking)
            {
                player.GetComponent<Animator>().SetInteger("state", 3);
                playerBody.AddForce(new Vector2(0, 500));
                canJump = false;
            }
            if ((Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D)) && canJump && !isCrouched)
            {
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
            if ((Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKey(KeyCode.A)) && canJump && !isCrouched)
            {
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
            if ((Input.GetKeyDown(KeyCode.L)) && canJump && !isCrouched && !isAttacking)
            {
                player.GetComponent<Animator>().SetInteger("state", 5);
                isAttacking = true;
            }
            else if (Input.GetKeyUp(KeyCode.L))
            {
                isAttacking = false;
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                isCrouched = true;
                player.GetComponent<BoxCollider2D>().size = new Vector2(9.429f, 24f);
                player.GetComponent<BoxCollider2D>().offset = new Vector2(-1.551f, 11.808f);
                player.GetComponent<Animator>().SetInteger("state", 4);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isCrouched = false;
                player.GetComponent<BoxCollider2D>().size = new Vector2(9.429f, 30.197f);
                player.GetComponent<BoxCollider2D>().offset = new Vector2(-1.551f, 15.0198f);
                player.GetComponent<Animator>().SetInteger("state", 0);
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
            player.GetComponent<Animator>().SetInteger("state", 0);
        }
       }
}
