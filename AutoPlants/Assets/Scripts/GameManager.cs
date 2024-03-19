using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public List<BaseEntity> PlayerEntitiesPrefab;
    public List<BaseEntity> EnemyEntitiesPrefab;
    int unitsPerTeam = 1;

    List<BaseEntity> team1Entities = new List<BaseEntity>();
    List<BaseEntity> team2Entities = new List<BaseEntity>();

    void Start()
    {
        InstantiateUnits( ) ;
    }

    public List<BaseEntity> GetEntitiesAgainst(Team against)
    {
        Debug.Log("enemies: ", team2Entities[0]);
        if (against == Team.Team1)
            return team2Entities;
        else
            return team1Entities;
    }

    private void InstantiateUnits ( )
    {
        for(int i = 0; i < unitsPerTeam; i++)
        {
            // New unit for team 1
            int randomIndex = UnityEngine.Random.Range(0, PlayerEntitiesPrefab.Count - 1);
            BaseEntity newEntity = Instantiate(PlayerEntitiesPrefab[randomIndex]);
            team1Entities.Add(newEntity);

            newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1));

            // New unit for team 2
            randomIndex = UnityEngine.Random.Range(0, EnemyEntitiesPrefab.Count - 1);
            newEntity = Instantiate(EnemyEntitiesPrefab[randomIndex]);
            team2Entities.Add(newEntity);

            newEntity.Setup(Team.Team2, GridManager.Instance.GetFreeNode(Team.Team2));
        }
    }
}

public enum Team
{
    Team1,
    Team2
}