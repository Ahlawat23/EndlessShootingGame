using UnityEngine;

public class gunMechnaism : MonoBehaviour
{
    public float damage = 10f;
    public float range = 110f;

    public Camera cam;

    public GameObject muzzleFlash;
    public float muzzleTime = 0.5f;

    public GameObject hitFlash;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            setMuzzleFlash();
        }
    }

    private void Shoot()
    {
        //creates a raycast from the palyer camera
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            ZombieScript enemy = hit.transform.GetComponent<ZombieScript>();
            if(enemy!= null)
            {
                enemy.TakeDamage(damage);
            }

            //handles the particle system
            GameObject impactFlash = Instantiate(hitFlash, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactFlash, 0.5f);
        }
    }

    void setMuzzleFlash()
    {
        //activates the muzzle flash
        muzzleFlash.SetActive(true);
        Invoke("unsetMuzzleFlash", muzzleTime);
    }

    void unsetMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }

}
