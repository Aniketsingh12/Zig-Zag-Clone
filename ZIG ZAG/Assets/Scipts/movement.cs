using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody rb;
    bool walkingright = true;
    private Animator anim;
    public Transform raystart;
    private GameManager manager;
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        anim = GetComponent<Animator>();
        manager = FindObjectOfType<GameManager>();
        
    }

    private void FixedUpdate()
    {
        if (!manager.gamestart)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gamestart");
        }



        rb.transform.position = transform.position + transform.forward *2* Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();

        }
        RaycastHit hit;

        if (!Physics.Raycast(raystart.position, -transform.up, out hit, Mathf.Infinity))
            anim.SetTrigger("isFalling");
           
        if(transform.position.y < -2)
        {
            manager.Endgame();
        }
        
    }
    void Switch()
    {
        if (!manager.gamestart)
            return;
        walkingright = !walkingright;

        if (walkingright)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "crystal")
        {
            Destroy(other.gameObject);
            manager.Incscore();
        }
    }
}
