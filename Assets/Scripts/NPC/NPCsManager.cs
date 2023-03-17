using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCsManager : MonoBehaviour
{
    #region Singleton
    public static NPCsManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public List<NPC> npcs;

    public NPC GetNpc(NPCNames name)
    {
        for (int i = 0; i < npcs.Count; i++)
        {
            if (npcs[i].name == name)
            {
                return npcs[i]; 
            }
        }

        return null;
    }
}

public enum NPCNames
{
    TEST_NPC,
    SECOND_TEST_NPC
}

[Serializable]
public class NPC
{
    public NPCNames name;
    public Sprite npcTalkSprite;
    public NpcInteractable npcInteractable;
}
