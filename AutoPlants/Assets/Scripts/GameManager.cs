using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : Manager<GameManager>
{
    public EntitiesDatabaseSO entitiesDatabase;
    public EntitiesDatabaseSO enemyEntitiesDatabase;

    public Transform team1Parent;
    public Transform team2Parent;

    public Action OnRoundStart;
    public Action OnRoundEnd;
    public Action<BaseEntity> OnUnitDied;

    List<BaseEntity> team1Entities = new List<BaseEntity>();
    List<BaseEntity> team2Entities = new List<BaseEntity>();

    public ShopManager shopManager;
    public GameObject mainCamera;

    int unitsPerTeam = 6;

    void Start(){
        // InstantiateUnits();
    }

    void Update(){
        if(shopManager.counter == 6){
            shopManager.counter = 0;
            mainCamera.transform.position = new Vector3(2.52f, -1.48f, -3.76f);
            foreach(BaseEntity entity in shopManager.chosenEntities){
                BaseEntity newEntity = Instantiate(entity);
                team1Entities.Add(newEntity);
                newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1));
            }
            Destroy(GameObject.Find("UI"));
            InstantiateUnits();
        }
    }

    public void OnEntityBought(EntitiesDatabaseSO.EntityData entityData)
    {
        BaseEntity newEntity = Instantiate(entityData.prefab, team1Parent);
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

    public void UnitDead(BaseEntity entity)
    {
        team1Entities.Remove(entity);
        team2Entities.Remove(entity);

        OnUnitDied?.Invoke(entity);

        Destroy(entity.gameObject);
    }

    public void InstantiateUnits ( )
    {
        for(int i = 0; i < unitsPerTeam; i++)
        {
            // New unit for team 1
            // int randomIndex = UnityEngine.Random.Range(0, entitiesDatabase.allEntities.Count);
            // BaseEntity newEntity = Instantiate(entitiesDatabase.allEntities[randomIndex].prefab);
            // team1Entities.Add(newEntity);

            // Debug.Log(GridManager.Instance.GetFreeNode(Team.Team1, entitiesDatabase.allEntities[randomIndex].type));
            // newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1, entitiesDatabase.allEntities[randomIndex].type));

            // New unit for team 2
            int randomIndex = UnityEngine.Random.Range(0, enemyEntitiesDatabase.allEntities.Count);
            BaseEntity newEntity = Instantiate(enemyEntitiesDatabase.allEntities[randomIndex].prefab);
            team2Entities.Add(newEntity);

            newEntity.Setup(Team.Team2, GridManager.Instance.GetFreeNode(Team.Team2, enemyEntitiesDatabase.allEntities[randomIndex].type));
        }
    }
}

public enum Team
{
    Team1,
    Team2
}