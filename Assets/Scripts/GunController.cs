using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public GameObject laser;
    public float fireDelta = 0.5F;
    public AudioSource fireAudioSource;

    GameController gameController;

    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        myTime = myTime + Time.deltaTime;

    }


    public EnemyController Fire()
    {
        if (myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            //打开laser
            StartCoroutine(showLaserForSec(0.1f));
            //播放开火声音
            fireAudioSource.Play();
            nextFire = nextFire - myTime;
            myTime = 0.0F;

            //发射的激光。
            Ray laserRay = new Ray(this.transform.position, this.transform.forward);
            RaycastHit rayHit;
            //Ray 击中一个collider，但不确定是不是敌人。
            if (Physics.Raycast(laserRay, out rayHit, Mathf.Infinity))
            {
                GameObject hitGameObject = rayHit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    //击中敌人加十分。
                    gameController.addScore(10);
                    //击中gameobject为Enemy证明ray击中敌人。
                    return hitGameObject.GetComponent<EnemyController>();

                }
            }
        }

        return null;
    }


    private IEnumerator showLaserForSec(float sec)
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(sec);
        laser.SetActive(false);
    }
}
