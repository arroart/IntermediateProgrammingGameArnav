using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 spawnPos;
    GameObject borderBor;
    public int hitScore;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText= GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        borderBor = GameObject.Find("Cube (2)");
        spawnPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == borderBor)
        {
            Debug.Log("aa");
            GameObject newBall=Instantiate(gameObject);
            newBall.transform.position = spawnPos;
            Destroy(gameObject);
        }

      

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HitShoot")
        {
            hitScore++;
            scoreText.text = hitScore.ToString();
        }
    }
}
