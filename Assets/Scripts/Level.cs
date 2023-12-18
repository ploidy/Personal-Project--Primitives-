using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
int level = 1;
int experience = 0;
[SerializeField] XpBar xpBar;

int TO_LEVEL_UP
{
    get
    {
        return level * 1000;
    }
}

private void Start()
{
    xpBar.UpdateXpSlider(experience, TO_LEVEL_UP);
    xpBar.SetLevelTest(level);
}

public void AddXp(int amount)
{
    experience += amount;
    CheckLevelUp();
    xpBar.UpdateXpSlider(experience, TO_LEVEL_UP);
}

public void CheckLevelUp()
{
    if(experience >= TO_LEVEL_UP)
    {
        experience -= TO_LEVEL_UP;
        level += 1;
        xpBar.SetLevelTest(level);
    }
}

}
