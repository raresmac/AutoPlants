using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<BaseEntity> allEntities;
    public List<BaseEntity> chosenEntities;
    public TextMeshProUGUI textmesh;
    public int counter = 0;
    public void choseChomper(){
        chosenEntities.Add(allEntities[0]);
        counter++;
        changeCounter();
    }
    public void chosePeashooter(){
        chosenEntities.Add(allEntities[1]);
        counter++;
        changeCounter();
    }
    public void choseWallnut(){
        chosenEntities.Add(allEntities[2]);
        counter++;
        changeCounter();
    }
    public void choseShroom(){
        chosenEntities.Add(allEntities[3]);
        counter++;
        changeCounter();
    }
    public void choseCattail(){
        chosenEntities.Add(allEntities[4]);
        counter++;
        changeCounter();
    }

    private void changeCounter(){
        textmesh.text = counter.ToString();
    }
}
