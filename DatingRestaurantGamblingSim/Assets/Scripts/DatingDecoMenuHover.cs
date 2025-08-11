using UnityEngine;

public class DatingDecoMenuHover : MonoBehaviour {
    [SerializeField] bool showing = false;
    [SerializeField] bool expanded = false;

    [SerializeField] Vector3 menu_hidden_position;
    [SerializeField] Vector3 menu_activated_position;

    Transform menu_transform;

    void Awake() {
        menu_transform = GameObject.Find("Menu/Background").GetComponent<Transform>();
        menu_transform.localPosition = menu_hidden_position;
    }

    void Start() {
        //
    }

    void Update() {
        //
    }

    void OnMouseEnter() {
        Debug.Log("hovering menu");
        showing = true;
        
    }

    void OnMouseExit() {
        Debug.Log("stopped hovering menu");
        showing = false;
    }

    void OnGUI() {
        
    }
    
    
}
