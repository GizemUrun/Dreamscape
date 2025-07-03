using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gm;
    [SerializeField] GameObject manager;

    [SerializeField] Rigidbody player;
    [SerializeField] float speed, turnSpeed;

    int movementControl = 0;

    public bool hasSceneChanged = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gm == null)
        {
            manager = GameObject.FindWithTag("GameController");
            gm = manager.GetComponent<GameManager>();
        }

        if (movementControl > 1 || movementControl < 0)
        {
            movementControl = Random.Range(0, 2);
        }
    }

    private void FixedUpdate() //movement
    {
        
        //move forwards and backwards
        if (movementControl == 0) //right way round
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.velocity = transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.velocity = -transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }
        }

        if (movementControl == 1) //inverse
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.velocity = -transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.velocity = transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Change") //scene change
        {
            gm.ChangeScene();
            movementControl = Random.Range(0, 2);
        }

        if (collision.collider.tag == "Wake") //wake up
        {
            gm.WakeUp();
        }
    }
}
