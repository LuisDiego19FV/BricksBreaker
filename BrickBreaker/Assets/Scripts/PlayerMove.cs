using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody rbPlayer;

    public float forceMultiplier;
    public float dragMultiplier;

    // Use this for initialization
    void Start () {
        rbPlayer = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rbPlayer.AddForce(-1f * forceMultiplier, 0, 0);
            rbPlayer.drag = 0;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rbPlayer.AddForce(1f * forceMultiplier, 0, 0);
            rbPlayer.drag = 0;
        }

        else
            rbPlayer.drag = 1 * dragMultiplier;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Intro");
        }

    }
}
