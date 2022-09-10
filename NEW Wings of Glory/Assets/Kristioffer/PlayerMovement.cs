using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    public Vector3 deltaMove;
    //public GameObject mover;

    private Rigidbody rb;

    public GameObject player;
    //private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //count = 0;
        //SetCountText();
        //winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Kan bevege seg baade horisontalt og vertikalt
        //Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //Kan bevege baade i x og z akse
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Kan kun bevege horisontalt
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        rb.AddForce(movement * speed);

        //player.gameObject.transform.forward;


    }

    /*void Update()
    {
        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        mover.transform.Translate(deltaMove);
    }*/


    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }*/

    /*void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 36)
        {
            winText.text = "You Win!";
        }
    }*/
}
