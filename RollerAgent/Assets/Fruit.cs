using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       if( other.gameObject.name.Contains("Dragonfruit")){
            // 스페이스바 누르면
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.SetParent(other.gameObject.transform);
                this.transform.localPosition = Vector3.zero;
                GameManager1.Instance.count++;
            }
        }
    }
}
