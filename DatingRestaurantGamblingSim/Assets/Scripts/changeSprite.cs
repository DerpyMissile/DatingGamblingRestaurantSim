using UnityEngine;
using UnityEngine.EventSystems;

public class changeSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite defaultSprite;
    public Sprite selectedSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = selectedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }
}
