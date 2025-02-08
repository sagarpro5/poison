using UnityEngine;

public class speedrunsave
{
    public int highmilesecond;
    public int highsecond;
    public int highminites;
    public int highhours;

    public speedrunsave(movement player)
    {
        highmilesecond = player.highmilesecond;
        highsecond = player.highsecond;
        highminites = player.highminites;
        highhours = player.highhours;
    }
}
