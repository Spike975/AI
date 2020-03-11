using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    private GameObject town;
    public int enemies;
    public float spawns;
    private float spawned;
    private int recomend = 1;
    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        town = GameObject.Find("Town");
        enemies = 0;
        if (spawns == 0)
        {
            spawns = 15f;
        }
        spawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !once)
        {
            once = true;
            recomend++;
        }
        if ((Time.time-spawned) > spawns && GameObject.FindGameObjectsWithTag("Enemy").Length - recomend < 3)
        {
            spawned = Time.time;
            GameObject e = Instantiate(enemy, new Vector3(spawn.transform.position.x, -1.3f, spawn.transform.position.z), Quaternion.LookRotation(new Vector3()));
            e.name = "Enemy " + enemies;
            once = false;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= recomend)
        {
            GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in e)
            {
                i.GetComponent<Enemy>().enabled = true;
                i.GetComponent<EnemyReturn>().enabled = false;
            }
        }
        if (town.GetComponent<Town>().health <= 0)
        {
            GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject i in e)
            {
                i.GetComponent<Enemy>().enabled = false;
                i.GetComponent<EnemyReturn>().enabled = true;
            }
        }
    }
}
