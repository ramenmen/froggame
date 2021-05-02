using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public GameObject tongue;

    private HingeJoint2D hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Connect(bool connect) {
        tongue.SetActive(connect);
        hinge.enabled = connect;
    }
}
