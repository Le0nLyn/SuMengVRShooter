using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GunController gunController;

    private void Awake()
    {
        gunController = FindObjectOfType<GunController>();
    }


    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            EnemyController hitEnemy = gunController.Fire();

            if (hitEnemy != null)
            {
                hitEnemy.DestroySelf();
            }
        }
    }

}
