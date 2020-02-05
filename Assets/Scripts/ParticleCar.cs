using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCar : MonoBehaviour
{
    public GameObject Obj;
    private Vector3 posObj;
    // Start is called before the first frame update
    private void Start()
    {
        posObj = new Vector3(Obj.transform.position.x, transform.position.y, transform.position.z);
        transform.position = posObj;
    }

    // Update is called once per frame
    void Update()
    {
        posObj = new Vector3(Obj.transform.position.x, transform.position.y, transform.position.z);
        transform.position = posObj;
    }
}
