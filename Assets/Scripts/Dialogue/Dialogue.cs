using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "new Dialogue", menuName = "Dialogues/new Dialogue")]
public class Dialogue : ScriptableObject
{
    public string NPCName;
    public Sprite otherPersonSprite;
    public List<Reply> replies;
}
[Serializable]
public class Reply
{
    public bool isPlayer;
    public string message;
    public float speed;
}

