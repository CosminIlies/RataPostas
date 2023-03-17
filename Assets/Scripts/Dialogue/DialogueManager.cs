using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Singleton

    public static DialogueManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject dialogueGui;

    [SerializeField]
    private Image whoIsTalkingImage;

    [SerializeField]
    private TMP_Text replyText;
    
    [SerializeField]
    private TMP_Text whoIsTalkingName;

    [SerializeField]
    private Sprite playerSprite;

    [SerializeField]
    private string playerName;

    private Dialogue currentDialogue;
    private NPC currentNpc;
    private int replyIndex = 0;

    private string toShowDialogue;
    private string currentShownDialogue;
    private bool isShowingDialogue = false;
    private bool shouldEndTheReply = false;

    public void StartDialogue(Dialogue dialogue, NPC npc)
    {
        currentDialogue = dialogue;
        currentNpc = npc;
        replyIndex = 0;
        isShowingDialogue = true;
        updateGui();
        Time.timeScale = 1;
        
    }

    public bool IsInDialoge()
    {
        return currentDialogue != null && currentNpc != null;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && currentDialogue != null)
        {
            if (!isShowingDialogue)
            {
                replyIndex++;
                if (replyIndex >= currentDialogue.replies.Count)
                {
                    replyIndex = 0;
                    currentDialogue = null;
                }
                isShowingDialogue = true;
                updateGui();
            }
            else
            {
                shouldEndTheReply = true;
            }
            
        }

    }

    IEnumerator ShowDialogue()
    {
        Reply reply = currentDialogue.replies[replyIndex];

       
        if (isShowingDialogue) { 
            for (int i = 0; i < toShowDialogue.Length; i++)
            {

                if (shouldEndTheReply || i == toShowDialogue.Length - 1)
                {
                    shouldEndTheReply = false;
                    isShowingDialogue = false;
                    replyText.text = toShowDialogue;
                    break;
                }



                currentShownDialogue += toShowDialogue[i];
                replyText.text = currentShownDialogue;



                yield return new WaitForSeconds(reply.speed);
            }
        }

    }

    private void updateGui()
    {
        if (currentDialogue == null)
        {
            dialogueGui.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        Reply reply = currentDialogue.replies[replyIndex];
        toShowDialogue = reply.message;
        currentShownDialogue = "";

        StartCoroutine(ShowDialogue());

        dialogueGui.SetActive(true);
        whoIsTalkingImage.sprite = reply.isPlayer ? playerSprite : currentNpc.npcTalkSprite;
        whoIsTalkingName.text = reply.isPlayer ? playerName : currentNpc.name.ToString();
    }
}
