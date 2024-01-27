using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    private float Rotaion = 0;
    [SerializeField] float RotaionSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotaion = Rotaion + RotaionSpeed;
        transform.rotation = Quaternion.Euler(Vector3.forward * Rotaion);
    }
}
