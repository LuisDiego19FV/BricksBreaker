using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public GameObject player;
    public Text txtVidas;
    public Text txtGo;

    private Vector3 velBall;
    private int vidas;
    private bool reStart;
    private bool vidaRestada;

	// Use this for initialization
	void Start () {

        reStart = false;
        vidaRestada = false;
        vidas = 3;

        velBall = new Vector3(Random.Range(-6, 6f), 0f, 11f);
        player.GetComponent<Rigidbody>().velocity = velBall;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (reStart)
        {
            player.transform.position = new Vector3(0f, 1f, -3f);
            velBall = new Vector3(Random.Range(-6, 6f), 0f, 11f);
            player.GetComponent<Rigidbody>().velocity = velBall;
            reStart = false;
            vidaRestada = false;
        }

        if (player.transform.position.z < -5 && !vidaRestada)
        {
            vidas--;
            txtVidas.text = "Vidas: " + vidas;
            vidaRestada = true;
        }

        if (player.transform.position.z < -20)
        {
            reStart = true;
        }

        if (vidas == 0)
        {
            txtGo.text = "GAME OVER";
            SceneManager.LoadSceneAsync("Intro");
        }

	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag.Equals("Brick"))
        {
            velBall = new Vector3(velBall.x, 0f, velBall.z * -1);
            player.GetComponent<Rigidbody>().velocity = velBall;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag.Equals("sideWalls"))
        {
            velBall = new Vector3(velBall.x *-1, 0f, velBall.z * -1);
            player.GetComponent<Rigidbody>().velocity = velBall;
        }

        else
        {

            if (other.gameObject.tag.Equals("PlayerR"))
            {
                velBall = new Vector3(velBall.x + 0.75f, 0f, velBall.z * -1.01f);
                player.GetComponent<Rigidbody>().velocity = velBall;
            }

            else if (other.gameObject.tag.Equals("PlayerL"))
            {
                velBall = new Vector3(velBall.x - 0.75f, 0f, velBall.z * -1.01f);
                player.GetComponent<Rigidbody>().velocity = velBall;
            }

            else
            {
                velBall = new Vector3(velBall.x, 0f, velBall.z * -1.01f);
                player.GetComponent<Rigidbody>().velocity = velBall;
            }
        }


    }
}
