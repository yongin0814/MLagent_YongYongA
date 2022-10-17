using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeAttack : MonoBehaviour
{
    public static TimeAttack Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public float time;
    public float limitTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Atack()
    {
        // 시간 흐르게 하기 
        time += Time.deltaTime;

        // 시간이 제한시간 지나면 
        if (GameManager1.Instance.count == 0 && time >= limitTime + 1)
        {
            GameManager1.Instance.loseUI.SetActive(true);
            // 게임오버 
            //SceneManager.LoadScene
        }

        // 시간이 제한시간 지나면 
        if (GameManager1.Instance.count > 0 && time >= limitTime + 1)
        {
                GameManager1.Instance.winUI.SetActive(true);
            // 게임오버 
            //SceneManager.LoadScene
        }
    }
}
