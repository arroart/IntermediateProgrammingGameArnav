using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShoot : MonoBehaviour
{
    bool shotAlready = false;
    bool shootingCurrently = false;
    Vector2 startHeight;
    Vector2 mouseStart;
    [SerializeField] Material shootingColor;
    Material normalColor;
    // Start is called before the first frame update
    void Start()
    {
        normalColor = GetComponent<MeshRenderer>().material;
        startHeight = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if(!shootingCurrently && !shotAlready)
            {
                
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 10f, 10f) * Time.fixedDeltaTime);
                gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotation);
                if (hit.point.z > -14f && hit.point.z < 14f)
                {
                    transform.position = new Vector3(startHeight.x, startHeight.y, hit.point.z);
                }
            }
            

            if (!shootingCurrently&&!shotAlready && Input.GetMouseButtonDown(0))
            {
                
                shootingCurrently = true;
                mouseStart.y = hit.point.y;
                mouseStart.x = hit.point.z;
                Debug.Log(mouseStart);
                gameObject.GetComponent<MeshRenderer>().material = shootingColor;
                
            }
            if (shootingCurrently && !shotAlready && Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<MeshRenderer>().material = normalColor;
                gameObject.GetComponent<Collider>().isTrigger = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3((mouseStart.y - hit.point.y) * -10f, 0f, (mouseStart.x-hit.point.z)*10f), ForceMode.Impulse);
                Debug.Log((mouseStart.y - hit.point.y));
                Debug.Log((mouseStart.x - hit.point.z));
                shotAlready = true;
                Invoke("SpawnShoot", 1f);


            }
        }

        
    }

    void SpawnShoot()
    {
        GameObject newShot = Instantiate(gameObject);
        newShot.transform.position = startHeight;
    }
}
