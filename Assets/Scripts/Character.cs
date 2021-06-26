using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Character
{
    // Name of the character
    public string characterName;

    // Root RectTransform
    [HideInInspector] public RectTransform root;

    // boolean that determines whether the item is enabled or not
    public bool enabled { get { return root.gameObject.activeInHierarchy; } set { root.gameObject.SetActive(value); } }

    // 
    public Vector2 anchorPadding {get { return root.anchorMax - root.anchorMin; } }

    // 
    DialogueSystem dialogueSys;

    #region Pissbabies

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="speech"></param>
    public void Say(string speech)
    {
        if (!enabled)
        {
            enabled = true;
        }

        dialogueSys.Say(speech, characterName);
    }

    // 
    Vector2 targetPos;
    Coroutine moving;
    bool isMoving { get { return moving != null; } }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    /// <param name="smooth"></param>
    public void MoveTo(Vector2 target, float speed, bool smooth = true)
    {
        StopMoving();

        // Start moving coroutine
        moving = CharacterManager.instance.StartCoroutine(Moving(target, speed, smooth));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arriveAtTargetPositionImmediately"></param>
    public void StopMoving(bool arriveAtTargetPositionImmediately = false)
    {
        if (isMoving)
        {
            CharacterManager.instance.StopCoroutine(moving);
            if (arriveAtTargetPositionImmediately)
            {
                SetPosition(targetPos);
            }
        }

        moving = null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Target"></param>
    public void SetPosition(Vector2 Target)
    {
        Vector2 padding = anchorPadding;

        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;

        Vector2 minAnchorTarget = new Vector2(maxX * targetPos.x, maxY * targetPos.y);

        root.anchorMin = minAnchorTarget;
        root.anchorMax = root.anchorMin + padding;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    /// <param name="smooth"></param>
    /// <returns></returns>
    IEnumerator Moving(Vector2 target, float speed, bool smooth)
    {
        targetPos = target;

        // Now we want to get the padding between the anchors of this cahracter so we know what their min and max positions are.
        Vector2 padding = anchorPadding;

        // Now get the limitations for 0 to 100% movement. The farthest a character can move to the right before reaching 100% should be the 1 value - the padding
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;

        // Now get the actual position target for the minimum anchors (left/bottom bounds) of the character, because maxX and maxY is just a percent reference
        Vector2 minAnchorTarget = new Vector2(maxX * targetPos.x, maxY * targetPos.y);
        speed *= Time.deltaTime; // premultiply the speed by Time.deltaTime

        // move until we reach the target position
        while(root.anchorMin != minAnchorTarget)
        {
            root.anchorMin = (!smooth) ? Vector2.MoveTowards(root.anchorMin, minAnchorTarget, speed) : Vector2.Lerp(root.anchorMin, minAnchorTarget, speed);
            root.anchorMax = root.anchorMin + padding;
            yield return new WaitForEndOfFrame();
        }

        StopMoving();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_name"></param>
    /// <param name="enableOnStart"></param>
    public Character (string _name, bool enableOnStart = true)
    {
        CharacterManager cm = CharacterManager.instance;
        // locate the character prefab
        GameObject prefab = Resources.Load("Prefabs/Characters/Character[" + _name + "]") as GameObject;
        GameObject characterInstance = GameObject.Instantiate(prefab, cm.characterPanel);

        root = characterInstance.GetComponent<RectTransform>();
        characterName = _name;

        Image characterRenderer = characterInstance.transform.Find("SpriteLayer").GetComponent<Image>();

        dialogueSys = DialogueSystem.instance;

        enabled = enableOnStart;
    }
}
