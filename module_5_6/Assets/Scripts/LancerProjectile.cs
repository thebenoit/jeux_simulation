using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float force = 5000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Lancer();
        }
    }

    public void Lancer()
    {
        GameObject proj = Instantiate(projectile);
        proj.transform.position = transform.position + transform.forward;
        proj.GetComponent<Rigidbody>().AddForce(transform.forward * force + Vector3.up * 50);
        Destroy(proj, 3f);
    }
}
