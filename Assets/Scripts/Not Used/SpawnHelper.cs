using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHelper : MonoBehaviour
{
    public GameObject NPCPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject npc = Instantiate(NPCPrefab, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
