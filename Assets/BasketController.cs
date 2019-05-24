using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource audioSource;
    GameObject gameDirector;


     void Start(){
        this.audioSource = GetComponent<AudioSource>();
        this.gameDirector = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple"){
            this.gameDirector.GetComponent<GameDirector>().GetApple();
            this.audioSource.PlayOneShot(this.appleSE);
        Debug.Log("Apple");
            }else{
            this.gameDirector.GetComponent<GameDirector>().GetBomb();
            this.audioSource.PlayOneShot(this.bombSE);
            Debug.Log("Bomb");
            }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //mainCamera上のメインカーソルのある位置から、Rayを飛ばす。

            if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                //Mathf.RoundToInt 小数点を四捨五入する関数。
                transform.position = new Vector3(x, 0.0f, z);

            }


        }
	}
}
