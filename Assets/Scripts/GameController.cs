using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] ObjGo;
    float startWait = 2;
    float spawnWait;
    GameObject leftOne, rightOne;

    int Score;
    int Speed;
    public Text ScoreText;
    //bool GameOverBool;
    float[] Xposition = new float[2] { 1.35f, 4.05f };
    // Start is called before the first frame update
    void Start()
    {
        //GameOverBool = false;
        StartCoroutine(SpawnObject());
        Score = 0;
        Speed = 10;
        startWait = 2;
        spawnWait = 1;
    }

    // Update is called once per frame
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < 50; i++)
            {

                float leftXPos = -Xposition[Random.Range(0, Xposition.Length)];
                Vector3 leftPos = new Vector3(leftXPos, 12, 0);
                leftOne = ObjGo[Random.Range(0, ObjGo.Length)] as GameObject;
                leftOne.GetComponent<XOGo>().speed = Speed;
                Instantiate(leftOne, leftPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);

                float rightXPos = Xposition[Random.Range(0, Xposition.Length)];
                Vector3 rightPos = new Vector3(rightXPos, 12, 0);
                rightOne = ObjGo[Random.Range(0, ObjGo.Length)] as GameObject;
                rightOne.GetComponent<XOGo>().speed = Speed;
                Instantiate(rightOne, rightPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    public void GameOver()
    {
        //GameOverBool = true;
    }

    public void CalcSpeed()
    {
        Speed = Mathf.Max(Speed, 10+Score/4);
    }

    public void CalcSpawn()
    {
        if (spawnWait > 0.3F && Speed > 10 && Speed % 5 == 0)
            spawnWait *= 0.8F;
    }

    public void AddScore()
    {
        Score += 1;
        ScoreText.text = Score.ToString();
        Debug.Log(Score);
    }
    public void DesScore()
    {
        Score -= 1;
        ScoreText.text = Score.ToString();
    }
}
