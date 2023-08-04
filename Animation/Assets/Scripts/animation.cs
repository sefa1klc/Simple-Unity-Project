using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    Vector3 position;
    Quaternion quat;

    // Start is called before the first frame update
    void Start()
    {
        position= transform.position;
        quat = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.D)) { 
            position = new Vector3(position.x,position.y, position.z+2f);
            quat = Quaternion.Euler(0, 360, 0);
            
        }
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 0.1f);


        if (Input.GetKeyDown(KeyCode.A))
        {
            position = new Vector3(position.x, position.y, position.z + -2f);
            quat = Quaternion.Euler(0, -180, 0);
            
        }
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 0.1f);

    }
}
