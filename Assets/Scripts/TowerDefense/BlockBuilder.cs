using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public int x;
    public int y;
    /// <summary>
    /// How Far away from start value for the spawn block(Positive values)
    /// </summary>
    public Vector3 spawnStart;
    /// <summary>
    /// How Far away from start value for the end spawn(Positive values)
    /// </summary>
    public Vector3 endStart;
    public GameObject target;
    public GameObject spawn;
    public GameObject end;
    private Vector3 start;
    // Update is called once per frame
    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Player").transform.position;
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                if (start.x + i == start.x +spawnStart.x && start.z + k == start.z + spawnStart.z)
                {
                    GameObject spawns = Instantiate(spawn, new Vector3(start.x + spawnStart.x - .5f, start.y + spawnStart.y - 1.5f, start.z + spawnStart.z + .5f), Quaternion.LookRotation(new Vector3()));
                    spawns.name = "Spawn";
                }
                else if (start.x + i == start.x + endStart.x && start.z + k == start.z + endStart.z)
                {
                    GameObject spawns = Instantiate(end,new Vector3(start.x + endStart.x -.5f, start.y + endStart.y - 1.5f, start.z + endStart.z + .5f), Quaternion.LookRotation(new Vector3()));
                    spawns.name = "End";
                }
                else
                {
                    GameObject spawns = Instantiate(target, new Vector3(start.x + i-.5f, start.y-1.5f, start.z + k+.5f), Quaternion.LookRotation(new Vector3()));
                    spawns.name = "Floor " + ((i * 10) + k); 
                }
            }
        }

    }
}
