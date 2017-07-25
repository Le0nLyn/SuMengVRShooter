using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {


    public GameObject EnemyPrefab;

    public Transform minx_minz;
    public Transform maxx_maxz;

    //测试。
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenerateEnemy(1);
        }
    }


    //在enemy platform上生成n个敌人。
    public void GenerateEnemy(int n)
    {

        for (int i = 0; i < n; i++)
        {
            //得到要生成敌人的随机位置，在min_x_min_z和max_x_max_z之前，y不变。
            float randomX = Random.Range(minx_minz.position.x, maxx_maxz.position.x);
            float randomZ = Random.Range(minx_minz.position.z, maxx_maxz.position.z);
            float yToUse = minx_minz.position.y;
            Vector3 positionToGenerate = new Vector3(randomX, yToUse, randomZ);
            //生成敌人。
            GameObject enemy = Instantiate(EnemyPrefab, positionToGenerate, EnemyPrefab.transform.localRotation);
        }
    }
}
