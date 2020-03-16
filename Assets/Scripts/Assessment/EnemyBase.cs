using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    public GameObject town;
    public int enemies;
    public int extra;
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
        //Checks to see if there are no enemies currenlty spawned, then adds one to the recomended amount for them to attack the town
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !once)
        {
            once = true;
            recomend++;
        }
        //Spawns the enemies at a given time and only if there isn't to many
        if ((Time.time-spawned) > spawns && GameObject.FindGameObjectsWithTag("Enemy").Length - recomend < extra)
        {
            spawned = Time.time;
            GameObject e = Instantiate(enemy, new Vector3(spawn.transform.position.x, -1.3f, spawn.transform.position.z), Quaternion.LookRotation(new Vector3()));
            e.name = "Enemy " + enemies;
            once = false;
        }
        //Checks to see if the amount of enemies has been meet, then switches the scripts
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= recomend && town.GetComponent<Town>().health > 0)
        {
            GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < e.Length; i++)
            {
                e[i].GetComponent<Enemy>().enabled = true;
                e[i].GetComponent<EnemyReturn>().enabled = false;
            }
        }
        //If the town has been deestroyed, switch scripts
        if (town.GetComponent<Town>().health <= 0)
        {
            GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < e.Length; i++)
            {
                e[i].GetComponent<Enemy>().enabled = false;
                e[i].GetComponent<EnemyReturn>().enabled = true;
            }
        }
    }
}
