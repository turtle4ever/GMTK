using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Round_start : MonoBehaviour
{
    private bool GameLost;

    public TMP_Text ScoreText;
    public TMP_Text HighscoreText;
    private IEnumerator Coroutine;
    public GameObject Round;
    public GameObject XLine;
    public GameObject YLine;
    public GameObject Restart;
    public GameObject GameOver;
    public CircleCollider2D Round2D;
    public BoxCollider2D XLine2D;
    public BoxCollider2D YLine2D;
    public float XLineSpeed;
    public float YLineSpeed;
    public float Score;
    static float Highscore;
    static float RoundRaiser;
    private void Start()
    {
        Coroutine = Rounds();
        StartCoroutine(Coroutine);
        ScoreText.SetText(Score.ToString());
        HighscoreText.SetText(Highscore.ToString());
        RoundRaiser = 1;
    }

    private IEnumerator Rounds()
    {
        while ( GameLost == false)
        {
            Round.GetComponent<Random_spawn>().CreateTarget();
            yield return new WaitUntil(() =>
            {
                XLine.transform.position += Vector3.right * XLineSpeed * RoundRaiser ;
                bool RightEdgeCheck = XLine.transform.position.x >= 12;
                bool PressedSpace = Input.GetKeyDown(KeyCode.Space);
                return RightEdgeCheck || PressedSpace;
            });
            yield return new WaitForEndOfFrame();
            yield return new WaitUntil(() =>
            {
                YLine.transform.position += Vector3.down * YLineSpeed * RoundRaiser;
                bool DownEdgeCheck = YLine.transform.position.y <= -5.75f;
                bool PressedSpace1 = Input.GetKeyDown(KeyCode.Space);
                return DownEdgeCheck || PressedSpace1 ;
            });
            if (Round2D.bounds.Intersects(XLine2D.bounds) == false || Round2D.bounds.Intersects(YLine2D.bounds) == false )
                GameLost = true;
            yield return new WaitForSeconds(0.5f);
            YLine.transform.position = new Vector2(0f, 5.63f);
            XLine.transform.position = new Vector2(-11.35f, 0f);
            if ( GameLost == false )
                Score++;
            if (Score > Highscore)
                Highscore = Score;
            ScoreText.SetText(Score.ToString());
            HighscoreText.SetText(Highscore.ToString());
            RoundRaiser += 0.05f;
        }
        Round.active = false;
        GameOver.active = true;
        Restart.active = true;
    }

}
