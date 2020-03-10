using UnityEngine;

public class Town : MonoBehaviour
{
    public float health;
    public float spawn;
    private float sTime;
    public GameObject villager;
    public GameObject spawnPoint;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        sTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - sTime > spawn && health > 0)
        {
            GameObject b = Instantiate(villager, new Vector3(spawnPoint.transform.position.x, -1.3f, spawnPoint.transform.position.z), Quaternion.LookRotation(new Vector3()));
            b.name = "Villager " + count;
            count++;
            sTime = Time.time;
        }
    }
}
