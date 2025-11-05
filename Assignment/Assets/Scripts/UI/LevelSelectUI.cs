using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    public void Level01Select()
    {
        GameManager.instance.LoadLevel("Level_01");
    }

    public void Level02Select()
    {
        GameManager.instance.LoadLevel("Level_02");
    }

    public void Level03Select()
    {
        GameManager.instance.LoadLevel("Level_03");
    }
}
