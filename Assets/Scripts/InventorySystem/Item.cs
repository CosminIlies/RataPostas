using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "new Item", menuName = "Items/new Item")]
public class Item : ScriptableObject
{
    public new string name;
    public string description;
    public float weight;
    public Sprite image;
    public NPCNames destinationNpc;
    public Dialogue dialogue;
    public float reward;
}


