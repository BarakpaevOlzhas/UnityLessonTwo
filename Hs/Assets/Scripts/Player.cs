using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float speed;
	// Use this for initialization

	[SerializeField]
	private float sideSpeed;

    public Action onGameOver;
    public Action onGameWin;

    private void Start () {
						
	}
	
	// Update is called once per frame
	private void Update () {
		rigidbody.AddForce(0,0,speed * Time.deltaTime);

		if(Input.GetKey(KeyCode.A)){
			rigidbody.AddForce(-sideSpeed * Time.deltaTime,0,0, ForceMode.VelocityChange);
		}
		else if(Input.GetKey(KeyCode.D)){
			rigidbody.AddForce(sideSpeed * Time.deltaTime,0,0,ForceMode.VelocityChange);
		}
        if (rigidbody.position.y < -10)
        {
            onGameOver();
        }
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Obstacle"){
			this.enabled = false;
            if (onGameOver != null)
            {
                onGameOver();
            }
        }
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Coin"){
			Destroy(other.gameObject);

			Debug.Log("Pick up coin!");
		}
		else if(other.tag == "Finish"){
			Debug.Log("You win!");

            if (onGameWin != null) {
                onGameWin();
            }
		}
	}
	

}
