using System.Collections;
using UnityEngine;

public class Slide : MonoBehaviour
{
    [SerializeField] Vector3 deactivatedPosition;
    [SerializeField] Vector3 activatedPosition;
    [SerializeField] float duration;

    private RectTransform objTransform;

    private enum EaseType{None, EaseIn, EaseOut, EaseInAndOut};
    private bool activated = false;
    private Coroutine slideCoroutine = null;

    void Awake() {
        objTransform = GetComponent<RectTransform>();
        objTransform.anchoredPosition = deactivatedPosition;
    }

    private void CheckCoroutine() {
        if(slideCoroutine != null) {
            StopCoroutine(slideCoroutine);
        }
    }

    public void ToggleNoEase() {
        CheckCoroutine();
        activated = !activated;
        slideCoroutine = StartCoroutine(slide(activated, EaseType.None));
    }

    public void ToggleEaseIn() {
        CheckCoroutine();
        activated = !activated;
        slideCoroutine = StartCoroutine(slide(activated, EaseType.EaseIn));
    }

    public void ToggleEaseOut() {
        CheckCoroutine();
        activated = !activated;
        slideCoroutine = StartCoroutine(slide(activated, EaseType.EaseOut));
    }

    public void ToggleEaseInAndOut() { // grin
        CheckCoroutine();
        activated = !activated;
        slideCoroutine = StartCoroutine(slide(activated, EaseType.EaseInAndOut));
    }

    private IEnumerator slide(bool activating, EaseType easing = EaseType.None) {
        Vector3 origin;
        Vector3 destination;

        if(activating) {
            destination = activatedPosition;
            origin = objTransform.anchoredPosition3D;
        } else {
            destination = deactivatedPosition;
            origin = objTransform.anchoredPosition3D;
        }

        float elapsed = 0.0f;
        while(elapsed < duration) {
            float t = elapsed / duration;
            switch(easing) {
                case EaseType.None:
                    t = elapsed;
                    break;
                case EaseType.EaseIn: // start slow
                    t = t * t;
                    break;
                case EaseType.EaseOut: // end slow
                    t = 1 - (1 - t) * (1 - t);
                    break;
                case EaseType.EaseInAndOut: 
                    t = Mathf.SmoothStep(0f, 1f, t);
                    break;
            }

            objTransform.anchoredPosition = Vector3.Lerp(
                origin,
                destination,
                t
            );
            elapsed += Time.deltaTime;
            yield return null;
        }

        // snap to end JIC (just in case)
        objTransform.anchoredPosition = destination;
    }
}
