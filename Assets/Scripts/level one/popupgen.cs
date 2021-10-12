using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupgen : MonoBehaviour
{
    public GameObject popup;
    public Transform mcpos;
    float timespec = 0f;
    List<GameObject> actpops = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("destroyOldpops", 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timespec += Time.deltaTime;
        float timebar = 2f;
        if (timespec>timebar)
        {
            int x = (int)Random.Range(mcpos.position.x+4,
                              mcpos.position.x + 9);

            int y = (int)Random.Range(mcpos.position.y,
                                      mcpos.position.y + 3);
            spawnpop(x, y);
            timespec = 0f;
            timebar -= Time.deltaTime*10;
        }
    }

    void spawnpop(int x, int y)
    {
        GameObject p = Instantiate(popup, new Vector2(x, y), Quaternion.identity);
        actpops.Insert(0, p);
    }

    void destroyOldpops()
    {
        Destroy(actpops[actpops.Count - 1]);
        actpops.RemoveAll(s => s == null);
    }
}
