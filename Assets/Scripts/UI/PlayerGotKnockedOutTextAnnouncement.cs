using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class PlayerGotKnockedOutTextAnnouncement : MonoBehaviour
{
    public float messageDisplayTime;
    [TextArea]
    public string message;
    private TMP_Text text;
    private Image parantePanelImage;
    private Color initialPanelColor;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        parantePanelImage = GetComponentInParent<Image>();
        initialPanelColor = parantePanelImage.color;
        parantePanelImage.color = Color.clear;
    }

    void PlayerLeftArena(object obj, Transform trans)
    {
        StartCoroutine(DisplayText(trans));
    }

    IEnumerator DisplayText(Transform trans)
    {
        parantePanelImage.color = initialPanelColor;
        text.text = string.Format(message, trans.name);
        yield return new WaitForSeconds(messageDisplayTime);
        text.text = "";
        parantePanelImage.color = Color.clear;
    }


    private void OnEnable()
    {
        PlayerInOutOfArenaTrigger.PlayerLeftArenaEvent += PlayerLeftArena;

    }
    private void OnDisable()
    {
        PlayerInOutOfArenaTrigger.PlayerLeftArenaEvent -= PlayerLeftArena;

    }
}
