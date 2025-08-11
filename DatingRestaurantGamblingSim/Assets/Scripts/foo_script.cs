using System.Collections;
using UnityEngine;

public class foo_script : MonoBehaviour
{
    [SerializeField] Vector3 deactivated_position;
    [SerializeField] Vector3 activated_position;
    [SerializeField] float duration;

    private enum EaseType{None, EaseIn, EaseOut, EaseInAndOut};
    private bool activated = false;
    private Coroutine slide_coroutine = null;

    private void chk_coroutine() {
        if(slide_coroutine != null) {
            StopCoroutine(slide_coroutine);
        }
    }

    public void toggle_noease() {
        chk_coroutine();
        activated = !activated;
        slide_coroutine = StartCoroutine(slide(activated, EaseType.None));
    }

    public void toggle_easein() {
        chk_coroutine();
        activated = !activated;
        slide_coroutine = StartCoroutine(slide(activated, EaseType.EaseIn));
    }

    public void toggle_easeout() {
        chk_coroutine();
        activated = !activated;
        slide_coroutine = StartCoroutine(slide(activated, EaseType.EaseOut));
    }

    public void toggle_easeinandout() { // grin
        chk_coroutine();
        activated = !activated;
        slide_coroutine = StartCoroutine(slide(activated, EaseType.EaseInAndOut));
    }

    private IEnumerator slide(bool activating, EaseType easing = EaseType.None) {
        Transform transform = GetComponent<Transform>();

        Vector3 origin;
        Vector3 destination;

        if(activating) {
            destination = activated_position;
            origin = (transform.localPosition == deactivated_position) ? deactivated_position : transform.localPosition;
        } else {
            destination = deactivated_position;
            origin = (transform.localPosition == activated_position) ? activated_position : transform.localPosition;
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

            transform.localPosition = Vector3.Lerp(
                origin,
                destination,
                t
            );
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
