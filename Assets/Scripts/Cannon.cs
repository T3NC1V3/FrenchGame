using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject cannonballInstance;
    [SerializeField] float cannonForce;
    bool isLit;
    bool isShot;
    bool isLoaded;
    [SerializeField] float cooldown;
    [SerializeField] float timeLit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLit && !isShot && Mathf.Round((Time.timeSinceLevelLoad - timeLit) * 100)/100 == 3)
        {
            Fire();
            isLit = false;
            isShot = true;
        }
    }

    void Fire()
    {
        GameObject cannonBall = Instantiate(cannonballInstance);
        cannonBall.transform.position = cannonballInstance.transform.position;
        cannonBall.SetActive(true);
        cannonBall.GetComponent<Rigidbody>().AddForce((transform.forward) * cannonForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Match")
        {
            if (!isLit)
            {
                timeLit = Time.timeSinceLevelLoad;
                isLit = true;
                isShot = false;
            }
        }
    }
}
