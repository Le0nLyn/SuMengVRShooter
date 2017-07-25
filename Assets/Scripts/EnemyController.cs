using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float destroyAfter;

    public GameObject group;

    private AudioSource dieAudio;

    private void Awake()
    {
        dieAudio = this.GetComponent<AudioSource>();
        //自动摧毁
        Destroy(this.gameObject, destroyAfter);
    }

    public void DestroySelf()
    {
        //播放被击中叫声。
        dieAudio.Play();
        //关闭collider
        this.GetComponent<Collider>().enabled = false;
        Destroy(group.gameObject);
        Destroy(this.gameObject, 1f);
    }
}
