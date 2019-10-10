using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text WinText;

    void Start(){
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      WinText.text = "";
    }
    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");             //grab input from player through keyboard


      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);  //y is zero because we dont want to move up

      rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("Pick up")){
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
      }
    }

    void SetCountText(){
      countText.text = "Count: " + count.ToString();
      if (count >= 8){
        WinText.text = "You Win!";
      }
    }
}
