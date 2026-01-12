using System.Collections.Generic;
using UnityEngine;

public class TestLifecycle : MonoBehaviour
{
    private List<int> list;
    void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
        list = new List<int>();
        string a = "hedef";
        a = a + "x";
        //Instantiate(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       //list = new List<int>();
        //Destroy(gameObject);
        
    }

    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
        
    }

    void LateUpdate()
    {
        //Debug.Log("LateUpdate");
        
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
