using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RankListRead : MonoBehaviour
{
    List<Score> scoreList = new List<Score>(); //创建list，用来存Score
    public GameObject Item;

    // Start is called before the first frame update
    void Start()
    {

        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/RankingList.txt");

        string nextLine;

        while ((nextLine = sr.ReadLine()) != null)

        {

            scoreList.Add(JsonUtility.FromJson<Score>(nextLine));

        }

        sr.Close();//将所有存储的分数全部存到list中

    }

    // Update is called once per frame
    public void AddScore()
    {
        Scorefollow scorefollow = GameObject.FindGameObjectWithTag("Score").GetComponent<Scorefollow>();
        int numScore = scorefollow.score;
        scoreList.Add(new Score(numScore));//分数名字直接调变量，不用给出细节
    }

    public void loadRankList()
    {

        scoreList.Sort();

        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/RankingList.txt");

        if (scoreList.Count > 10) for (int i = 10; i <= scoreList.Count; i++) scoreList.RemoveAt(i);

        for (int i = 0; i < scoreList.Count; i++)

        {

            sw.WriteLine(JsonUtility.ToJson(scoreList[i]));

            Debug.Log(scoreList[i].ToString());

        }

        sw.Close();

    }

    public void ShowRanklist()
    {

        for (int i = 0; i < scoreList.Count; i++)

        {

            GameObject item = Instantiate(Item.gameObject);

            item.gameObject.SetActive(true);

            item.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();

            item.transform.Find("Score").GetComponent<Text>().text = scoreList[i].score.ToString();

        }

    }
}



public class Score : System.IComparable<Score>

{

    public int score;

    public Score(int s) { score = s; }

    public int CompareTo(Score other)

    {

        if (other == null)

            return 0;

        int value = other.score - this.score;

        return value;

    }

    public override string ToString()//debug用

    {

        return score.ToString();

    }

}
