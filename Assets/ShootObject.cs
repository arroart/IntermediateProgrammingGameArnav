using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    [SerializeField] GameObject spawnShoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.name == gameObject.name)
                {
                    GameObject shotBall=Instantiate(spawnShoot);
                    shotBall.transform.position = new Vector3(20f,-9f, hit.point.z);
                    shotBall.GetComponent<Rigidbody>().AddForce(new Vector3(-100f, 0, 0f), ForceMode.Impulse);

                    Debug.Log("aa");
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "Cube(2)")
        {
            Destroy(gameObject);
        }
    }
}
