using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    //It is processed after Update being processed
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVetical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f , moveVetical);

        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
      //delete from the scene
      //Destroy(other.gameObject);

      //Tag used here is added to Inspector->Tag of pointed objects
      if (other.gameObject.CompareTag("PickUp"))
      {
        other.gameObject.SetActive (false);
        count = count + 1;
        SetCountText();
      }
    }

    void SetCountText()
    {
      countText.text = "Count : " + count.ToString();
      if (count >=12)
      {
        winText.text = "You win!";
      }
    }
}
