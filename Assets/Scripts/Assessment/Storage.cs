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

    //Really just a means to store data
    private void Start()
    {
        building = 20;
        mineCap = 100;
        foodCap = 50;
        coinCap = 150;
        buildCap = 100;
    }
}
