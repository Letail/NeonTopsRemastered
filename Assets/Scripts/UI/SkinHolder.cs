using System.Collections.Generic;
using UnityEngine;

public class SkinHolder : MonoBehaviour
{
    public GameObjectListSO skinsListSO;
    [SerializeField] private float offsetY;
    private List<GameObject> spawnedSkinsList;
    private int skinsListSize;
    private int currentIndex;
    private float coolDown = 1f;
    private float lastTimeChanged = 0;

    private void Start()
    {
        currentIndex = 0;
        spawnedSkinsList = new List<GameObject>();
        foreach (var item in skinsListSO.list)
        {
            GameObject spawnedSkin = Instantiate(item);
            spawnedSkin.transform.parent = transform;
            spawnedSkin.transform.localPosition = new Vector3(0, offsetY, 0); 
            spawnedSkin.SetActive(false);
            spawnedSkinsList.Add(spawnedSkin);
        }
    }

    public int ChangeDisplayedSkin(Vector2 navigation)
    {
        if(Time.time > lastTimeChanged + coolDown)
        {
            if (navigation == Vector2.right) SwitchDisplay(IncreaseIndex());
            else if (navigation == Vector2.left) SwitchDisplay(DecreaseIndex());
            lastTimeChanged = Time.time;
        }
        
        return currentIndex;
    }

    private void SwitchDisplay(int index)
    {
        foreach (var item in spawnedSkinsList)
        {
            item.SetActive(false);
        }
        spawnedSkinsList[index].SetActive(true);
        Debug.Log("Activate skin of index" + index);
    }

    private int IncreaseIndex()
    {
        skinsListSize = skinsListSO.list.Count;
        if (currentIndex == skinsListSize - 1)
        {
            currentIndex = 0;
        }
        else
            currentIndex++;

        return currentIndex;
    }
    private int DecreaseIndex()
    {
        skinsListSize = skinsListSO.list.Count;
        if (currentIndex == 0)
        {
            currentIndex = skinsListSize - 1;
        }
        else
            currentIndex--;

        return currentIndex;
    }
}
