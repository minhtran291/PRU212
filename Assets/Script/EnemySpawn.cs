using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;
    [SerializeField] Transform[] Positions;
    [SerializeField] float timeSpam = 2f;
    private List<GameObject> listSpamEnemy = new List<GameObject>();
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        DayAndNight dayAndNight = FindAnyObjectByType<DayAndNight>();
       while (true)
        {
            if (!dayAndNight.isDay)
            {
                yield return new WaitForSeconds(6);
                for(int i = 0; i < listSpamEnemy.Count; ++i)
                {
                    if (listSpamEnemy[i] != null)
                    {
                        DestroyImmediate(listSpamEnemy[i],true);
                    }
                }
                listSpamEnemy.Clear();
            }
            else
            {
                var time = Mathf.Max(1, timeSpam - dayAndNight.gameDay);
                yield return new WaitForSeconds(time);
                Transform pos = Positions[Random.Range(0, Positions.Length)];
                GameObject enemy = Enemies[Random.Range(0, Enemies.Length)];
                var enemies = Instantiate(enemy, pos.position, Quaternion.identity);
                listSpamEnemy.Add(enemy);
            }
        }
    }
}
