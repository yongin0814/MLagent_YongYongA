using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 이 스크립트는 매니저에 붙는거다 

// box destroy 되면 3초 뒤에 용 가져오기
public class gamemanaging : MonoBehaviour
{
    public GameObject Dragon;
    public GameObject DragonPoint;

    //private bool dragonYes = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DragonInstant();
    }

/*    private void DragonInstant()
    {

        // 만약 박스 없으면
        if ((GameObject.Find("FruitBox") == false) && dragonYes == false)
        {
            // 용 나와
            Instantiate(Dragon,DragonPoint.transform);

            //// 드래곤 포인트에.
            //Dragon.transform.position = DragonPoint.transform.forward;

            // dragonYes == true로 바꿔주기!
            dragonYes = true;


        }
    }*/
}
