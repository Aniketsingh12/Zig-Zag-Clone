using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createroad : MonoBehaviour
{
    public GameObject roadpre;
    public Vector3 lastpos;
    public float offset = 0.655f;
    private int roadcount = 0;
    

    // Update is called once per frame
    public void startbuild()
    {
        InvokeRepeating("createroadpart", 1f, .1f);
    }

    public void createroadpart()
    {
        Debug.Log("new road");
        Vector3 spawn = Vector3.zero;
        float chance = Random.Range(1, 100);
        if (chance < 50)
        {
            spawn = new Vector3(lastpos.x + offset, lastpos.y, lastpos.z + offset);
        }
        else
        {
            spawn = new Vector3(lastpos.x - offset, lastpos.y, lastpos.z + offset);
        }
        GameObject g = Instantiate(roadpre,spawn, Quaternion.Euler(0,45,0));
        lastpos = g.transform.position;

        roadcount++;
        if(roadcount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
}
