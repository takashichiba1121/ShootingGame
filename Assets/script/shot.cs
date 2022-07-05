using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //íeÇê∂ê¨Ç∑ÇÈ
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
