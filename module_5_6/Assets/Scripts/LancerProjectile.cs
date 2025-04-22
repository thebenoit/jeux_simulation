using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float force = 5000;

    private bool _lancerProjectile = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _lancerProjectile = true;
        }
    }

    public void FixedUpdate()
    {   
        if (_lancerProjectile)
        {
            GameObject proj = Instantiate(projectile);
            proj.transform.position = transform.position + transform.forward;
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * force + Vector3.up * 50);
            _lancerProjectile = false;
            // détruire le projectile après 3 secondes
            Destroy(proj, 3f);


            
        }
    }
}
