using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    private GameObject destroyer;//unity‚¿‚á‚ñ‚Ì“ü‚ê•¨‚ğì¬
    // Start is called before the first frame update
    void Start()
    {
        this.destroyer = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < destroyer.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
