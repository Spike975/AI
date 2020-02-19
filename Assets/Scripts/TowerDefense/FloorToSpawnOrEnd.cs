using UnityEngine;

public class FloorToSpawnOrEnd : MonoBehaviour
{
    public GameObject spawn;
    public GameObject end;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    GameObject spaw = Instantiate(gameObject, GameObject.Find("Spawn").transform.position, Quaternion.LookRotation(new Vector3()));
                    spaw.name = gameObject.name;
                    Destroy(GameObject.Find("Spawn"));
                    GameObject spawns = Instantiate(spawn, gameObject.transform.position, Quaternion.LookRotation(new Vector3()));
                    spawns.name = "Spawn";
                    Destroy(gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    GameObject spaw = Instantiate(gameObject, GameObject.Find("End").transform.position, Quaternion.LookRotation(new Vector3()));
                    spaw.name = gameObject.name;
                    Destroy(GameObject.Find("End"));
                    GameObject spawns = Instantiate(end, gameObject.transform.position, Quaternion.LookRotation(new Vector3()));
                    spawns.name = "End";
                    Destroy(gameObject);
                }
            }
        }
    }
}
