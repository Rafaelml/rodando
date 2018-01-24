using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
    private int count_total;
    private GameObject[] picks;
    public Text countText;
    public Text ganador;
    private void Start(){
        picks = GameObject.FindGameObjectsWithTag("Picks up");
        count_total = picks.Length;
        rb = GetComponent<Rigidbody>();
        count = 0;
        CountText();
        ganador.text = "";
    }
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Picks up")) {
            other.gameObject.SetActive(false);
            count += 1;            
            CountText();
            if(count == count_total)
            {
                ganador.text = "Ganaste";
            }

        }
    }
    void CountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
