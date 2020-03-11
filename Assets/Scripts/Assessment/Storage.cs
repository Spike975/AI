using UnityEngine;

public class Storage : MonoBehaviour
{
    public float mine;
    public float mineCap;
    public float food;
    public float foodCap;
    public float building;
    public float buildCap;
    public float coin;
    public float coinCap;

    private void Start()
    {
        mineCap = 100;
        foodCap = 50;
        coinCap = 150;
    }
}
