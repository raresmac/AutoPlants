using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public BaseEntity currentTarget;
    void Update()
    {
        if(currentTarget == null){
            Destroy(gameObject);
            return;
        }
        if(Vector3.Distance(transform.position, currentTarget.transform.position) <= 0.2f){
            Destroy(gameObject);
        }
    }
}
