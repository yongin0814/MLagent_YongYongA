using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int count;
    bool isBunny = false;
    public GameObject Dragon;
    //public GameObject DragonPoint;

    public GameObject winUI;
    public GameObject loseUI;

    private bool dragonYes = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        winUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 4 && isBunny == false)
        {
            isBunny = true;
            StartCoroutine("Bunny");
        }
        print(count);

/*        // 만약 박스 없으면
        if ((GameObject.Find("FruitBox") == false) && dragonYes == false)
        {
            // 용 나와
            Instantiate(Dragon, DragonPoint.transform);

            //// 드래곤 포인트에.
            //Dragon.transform.position = DragonPoint.transform.forward;

            // dragonYes == true로 바꿔주기!
            dragonYes = true;


        }*/
    }

    IEnumerator Bunny()
    {
        yield return new WaitForSeconds(2f);
        Dragon.SetActive(true);
        TimeAttack.Instance.Atack();
        if (count == 0)
        {
            winUI.SetActive(true);
        }
    }
}
