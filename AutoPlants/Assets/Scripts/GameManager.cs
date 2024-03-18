using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public List<BaseEntity> allEntitiesPrefab;
    Dictionary<Team, List<BaseEntity>> entitiesByTeam = new Dictionary<Team, List<BaseEntity>>(); 
    int unitsPerTeam = 1;

    List<BaseEntity> team1Entities = new List<BaseEntity>();
    List<BaseEntity> team2Entities = new List<BaseEntity>();

    void Start()
    {
        InstantiateUnits( ) ;
    }

    public List<BaseEntity> GetEntitiesAgainst(Team against)
    {
        if (against == Team.Team1)
            return team2Entities;
        else
            return team1Entities;
    }

    private void InstantiateUnits ( )
    {
        entitiesByTeam.Add(Team.Team1, new List<BaseEntity>());
        entitiesByTeam.Add(Team.Team2, new List<BaseEntity>());
        for(int i = 0; i < unitsPerTeam; i++)
        {
            // New unit for team 1
            int randomIndex = UnityEngine.Random.Range(0, allEntitiesPrefab.Count - 1);
            BaseEntity newEntity = Instantiate(allEntitiesPrefab[randomIndex]);
            entitiesByTeam[Team.Team1].Add(newEntity);

            newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1));

            // New unit for team 2
            randomIndex = UnityEngine.Random.Range(0, allEntitiesPrefab.Count - 1);
            newEntity = Instantiate(allEntitiesPrefab[randomIndex]);
            entitiesByTeam[Team.Team2].Add(newEntity);

            newEntity.Setup(Team.Team2, GridManager.Instance.GetFreeNode(Team.Team2));
        }
    }
}

public enum Team
{
    Team1,
    Team2
}