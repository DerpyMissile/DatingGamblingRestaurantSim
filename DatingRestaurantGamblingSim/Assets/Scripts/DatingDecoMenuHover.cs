using UnityEngine;
using UnityEngine.EventSystems;

public class DatingDecoMenuHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    Slide slider;
    GameObject expandedMenu;
    GameObject expandedButton; // the options for decor and stuff

    void Awake() {
        slider = GetComponent<Slide>();
        expandedMenu = GameObject.Find("ExpandedMenu");
        expandedButton = GameObject.Find("Button_DecorOption");

        expandedMenu.SetActive(false);
        expandedButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        slider.ToggleEaseOut();
    }

    public void OnPointerExit(PointerEventData eventData) {
        slider.ToggleEaseOut();
        ToggleExpand();
        // KillButtons();
    }

    public void ToggleExpand() {
        expandedMenu.SetActive(!expandedMenu.activeSelf);
        if(expandedMenu.activeSelf) {
            SpawnButtons();
        }
    }

    private void SpawnButtons() {
        foreach ( var item in BurnerInventory.decorInventory ) {
            Debug.Log("spawn button");
        }
    }
}
