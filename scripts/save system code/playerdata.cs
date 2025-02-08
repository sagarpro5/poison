using UnityEngine;

[System.Serializable]
public class playerdata
{
    public int highscore;

    public playerdata(movement player)
    {
        highscore = player.highscore;
    }
}
