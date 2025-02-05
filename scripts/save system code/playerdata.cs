using UnityEngine;

[System.Serializable]
public class playerdata
{
    public int highscore;
    public int score;

    public playerdata(movement player)
    {
        highscore = player.highscore;
        score = player.score;
    }
}
