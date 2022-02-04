using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Camera mainCamera;

    public Camera morganCamera;

    public GameObject projectile;

    public float lauchSpeed;

    public GameObject currentHilmar;

    // Start is called before the first frame update
    void Start()
    {
        SetcurrentCamera(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHilmar != null) {
            morganCamera.transform.position = Vector3.Lerp(morganCamera.transform.position,
                currentHilmar.transform.position, Time.deltaTime * 5f);

            morganCamera.transform.rotation = Quaternion.LookRotation(currentHilmar.transform.up, 
                Vector3.up);
        }

        if (currentHilmar != null && currentHilmar.GetComponent<Projectile>().bHit == true) {
            gameObject.transform.position = currentHilmar.transform.position;
            Debug.Log("bHit is true!");
            SetcurrentCamera(true);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(currentHilmar);
        }

        if (Input.GetMouseButtonDown(0)) {

            Vector3 offset = mainCamera.transform.forward; ;

            if (currentHilmar == null) {
                
                currentHilmar = Instantiate(projectile, transform.position + offset * 0.9f, Quaternion.identity);
                Rigidbody projectileRB = currentHilmar.GetComponent<Rigidbody>();
                projectileRB.velocity = offset * lauchSpeed;
                SetcurrentCamera(false);
            }
            else {
                Destroy(currentHilmar);
                SetcurrentCamera(true);
            }
        }
    }

    void SetcurrentCamera(bool bMainCam) {
        if (bMainCam == true) {
            mainCamera.enabled = true;
            morganCamera.enabled = false;
        }
        else {
            mainCamera.enabled = false;
            morganCamera.enabled = true;
        }
        
    }
}
