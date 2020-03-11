using UnityEngine;

public class GuardPost : MonoBehaviour
{
    public GameObject guard;
    public GameObject spawn;
    
    public int cost;
    public int guardDeath;
    public bool spawned;
    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        cost = 50;
        guardDeath = 1;
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawned)
        {
            GameObject g = Instantiate(guard,new Vector3(spawn.transform.position.x, -1.3f, spawn.transform.position.z),Quaternion.LookRotation(new Vector3()));
            g.name = "Guard " + GameObject.FindGameObjectsWithTag("Guard").Length;
            spawned = false;
            once = false;
        }
        if (GameObject.FindGameObjectsWithTag("Guard").Length == 0 && !once)
        {
            guardDeath++;
            once = true;
        }else if (guardDeath < 0)
        {
            guardDeath = 0;
        }
    }
}
