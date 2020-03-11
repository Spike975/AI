using UnityEngine;

public class HireGuard : MonoBehaviour
{
    private GameObject post;
    private GameObject storage;

    
    // Start is called before the first frame update
    void Start()
    {
        post = GameObject.Find("GuardPost");
        storage = GameObject.Find("Storage");
    }

    // Update is called once per frame
    void Update()
    {
        if (post.GetComponent<GuardPost>().guardDeath > 0)
        {
            if (gameObject.GetComponent<Status>().money >= post.GetComponent<GuardPost>().cost)
            {
                if ((post.transform.position - transform.position).sqrMagnitude >= .5f)
                {
                    Vector3 v = ((post.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                    v.y = 0;
                    gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                }
                else
                {
                    post.GetComponent<GuardPost>().spawned = true;
                    gameObject.GetComponent<Status>().money -= post.GetComponent<GuardPost>().cost;
                    post.GetComponent<GuardPost>().guardDeath--;
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                    gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
                    gameObject.GetComponent<TownsFolk>().last = 0;
                    gameObject.GetComponent<HireGuard>().enabled = false;
                }
            }
            else
            {
                if ((storage.GetComponent<Storage>().coin + gameObject.GetComponent<Status>().money) >= post.GetComponent<GuardPost>().cost)
                {
                    if ((storage.transform.position - transform.position).sqrMagnitude >= .5f)
                    {
                        Vector3 v = ((storage.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                        v.y = 0;
                        gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                    }
                    else
                    {
                        int take = (int)(post.GetComponent<GuardPost>().cost - gameObject.GetComponent<Status>().money);
                        storage.GetComponent<Storage>().coin -= take;
                        gameObject.GetComponent<Status>().money += take;
                    }
                }
                else
                {
                    //Find out how to make money to hire guards
                    gameObject.GetComponent<TownsFolk>().current = 0;
                    gameObject.GetComponent<TownsFolk>().last = 1;
                    gameObject.GetComponent<HireGuard>().enabled = false;
                }
            }
        }
        else if (post.GetComponent<GuardPost>().guardDeath == 0)
        {
            gameObject.GetComponent<Movement>().velocity = new Vector3();
            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
            gameObject.GetComponent<TownsFolk>().last = 0;
            gameObject.GetComponent<HireGuard>().enabled = false;
        }
    }
}
