// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image; // ????

public class DatingDeco : MonoBehaviour {
	private int bgIndex = 0;
	private int decoLIndex = 0;
	private int decoRIndex = 0;
	private int tableIndex = 0;

	[SerializeField] public Sprite[] bgSprites; // snake case (grin)
	[SerializeField] public Sprite[] decoSprites;
	[SerializeField] public Sprite[] foodSprites;
	[SerializeField] public Sprite[] tableSprites;

	private Image bgRenderer;
	private Image decoLRenderer;
	private Image decoRRenderer;
	private Image tableRenderer;

	void Awake() {
		LoadRenderers();
	}
	
    void Start() {
		Draw();
	}

	void LoadRenderers() {
		bgRenderer = GameObject.Find("Scene (Canvas)/Background/Wall").GetComponent<Image>();
		decoLRenderer = GameObject.Find("Scene (Canvas)/Foreground/Decoration (Left)").GetComponent<Image>();
		decoRRenderer = GameObject.Find("Scene (Canvas)/Foreground/Decoration (Right)").GetComponent<Image>();
		tableRenderer = GameObject.Find("Scene (Canvas)/Foreground/Table").GetComponent<Image>();
	}

	void Draw() {
		bgRenderer.sprite = bgSprites[bgIndex];
		decoLRenderer.sprite = decoSprites[decoLIndex];
		decoRRenderer.sprite = decoSprites[decoRIndex];
		tableRenderer.sprite = tableSprites[tableIndex];
	}

	public void ChangeBg() { // TODO: this
		bgIndex = (bgIndex + 1) % bgSprites.Length;
		Draw();
	}

	public void changeDecoL() {
		decoLIndex = (decoLIndex + 1) % decoSprites.Length;
		Draw();
	}

	public void changeDecoR() {
		decoRIndex = (decoRIndex + 1) % decoSprites.Length;
		Draw();
	}

	public void changeTable() {
		tableIndex = (tableIndex + 1) % tableSprites.Length;
		Draw();
	}	
}

