using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private int count;
    public float speed = 0.0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject; 
    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rigidBody = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }


    // called right before physics happens
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 6)
        {
            winTextObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        rigidBody.AddForce(new Vector3(movementX, 0.0f, movementY)*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        
        
    }
}
