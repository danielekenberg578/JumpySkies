using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject dörr;

    public GameObject PickUp1;
    public GameObject PickUp2;
    public GameObject PickUp3;
    public GameObject PickUp4;

    private float Move;
    public float jumpAmount = 10;
    public float jumpPadAmount = 12;
    
    public bool isJumping;

    private Rigidbody2D rb;
    private int count;

    private Vector3 SpawnPoint;
    public GameObject FallMatta;


    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

        SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rörelse sidled
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // Hopp
         if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }


         if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = SpawnPoint;
            dörr.SetActive(true);
            count = 0;
            PickUp1.SetActive(true);
            PickUp2.SetActive(true);
            PickUp3.SetActive(true);
            PickUp4.SetActive(true);
            winTextObject.SetActive(false);
            SetCountText();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if(other.gameObject.CompareTag("Nyckel"))
        {
            GetComponent<Animator>().Play("dörr_slider");
        }

        if (other.gameObject.CompareTag("JumpPad"))
        {
            rb.AddForce(Vector2.up * jumpPadAmount, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count:  " + count.ToString();
        if(count >= 4)
        {
            winTextObject.SetActive(true);
        }
        if(count >= 1)
        {
            dörr.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("FallMatta"))
        {
            transform.position = SpawnPoint;
            dörr.SetActive(true);
            count = 0;
            PickUp1.SetActive(true);
            PickUp2.SetActive(true);
            PickUp3.SetActive(true);
            PickUp4.SetActive(true);
            winTextObject.SetActive(false);
            SetCountText();
            
        }

    }


}
