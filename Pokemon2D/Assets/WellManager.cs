using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellManager : MonoBehaviour
{
    RebuildWell rebuiltwell;

    [SerializeField] GameObject well;

    [SerializeField] GameObject enemySpawn;
    private void Awake()
    {
        rebuiltwell = FindObjectOfType<RebuildWell>();
        well = rebuiltwell.transform.gameObject;

        
    }

    private void Update()
    {
        if (well.activeInHierarchy)
        {
            enemySpawn.SetActive(true);
        }
    }
}
