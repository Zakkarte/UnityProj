using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_new : MonoBehaviour
{
    public CapsuleCollider playerCollider;
    public float moveSpeed = 5f;

    

    private RaycastHit hit;
    private Ray ray;
    public float rayDistance = 4f;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        transform.Translate(movement * Time.deltaTime * moveSpeed);

        ray = new Ray(transform.position + new Vector3(0f, playerCollider.center.y, 0f), transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < rayDistance)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    print("There is an enemy ahead");
                }
            }
        }
    }

    
}
