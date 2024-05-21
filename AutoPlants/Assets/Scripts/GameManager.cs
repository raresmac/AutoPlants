using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public EntitiesDatabaseSO playerEntitiesDatabase;
    public EntitiesDatabaseSO enemyEntitiesDatabase;

    public Transform plantsParent;
    public Transform enemiesParent;
    
    public Action OnRoundStart;
    public Action OnRoundEnd;

    public Action<BaseEntity> OnUnitDied;
    public int unitsPerTeam = 1;

    List<BaseEntity> team1Entities = new List<BaseEntity>();
    List<BaseEntity> team2Entities = new List<BaseEntity>();

    void Start()
    {
        InstantiateUnits( ) ;
    }

    public void OnEntityBought(EntitiesDatabaseSO.EntityData entityData)
    {
        BaseEntity newEntity = Instantiate(entityData.prefab, plantsParent);
        newEntity.gameObject.name = entityData.name;
        team1Entities.Add(newEntity);

        newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1));
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
        for(int i = 0; i < unitsPerTeam; i++)
        {
            // New unit for team 1
            int randomIndex = UnityEngine.Random.Range(0, playerEntitiesDatabase.allEntities.Count);
            BaseEntity newEntity = Instantiate(playerEntitiesDatabase.allEntities[randomIndex].prefab);
            team1Entities.Add(newEntity);

            newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1, playerEntitiesDatabase.allEntities[randomIndex].type));

            // New unit for team 2
            randomIndex = UnityEngine.Random.Range(0, enemyEntitiesDatabase.allEntities.Count);
            newEntity = Instantiate(enemyEntitiesDatabase.allEntities[randomIndex].prefab);
            team2Entities.Add(newEntity);

            newEntity.Setup(Team.Team2, GridManager.Instance.GetFreeNode(Team.Team2, enemyEntitiesDatabase.allEntities[randomIndex].type));
        }
    }

    public void UnitDead(BaseEntity entity)
    {
        team1Entities.Remove(entity);
        team2Entities.Remove(entity);

        OnUnitDied?.Invoke(entity);

        Destroy(entity.gameObject);
    }
}

public enum Team
{
    Team1,
    Team2
}