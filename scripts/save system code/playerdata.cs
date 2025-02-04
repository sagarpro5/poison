using UnityEngine;

[System.Serializable]
public class playerdata : MonoBehaviour
{
    public int score;

    public playerdata(movement player)
    {
        score = player.score;
    }
}
