// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class DatingDeco : MonoBehaviour {
	private int bg_index = 0;
	private int deco_l_index = 0;
	private int deco_r_index = 0;
	private int table_index = 0;

	[SerializeField] public Sprite[] bg_sprites; // snake case (grin)
	[SerializeField] public Sprite[] deco_sprites;
	[SerializeField] public Sprite[] food_sprites;
	[SerializeField] public Sprite[] table_sprites;

	private SpriteRenderer bg_renderer;
	private SpriteRenderer deco_l_renderer;
	private SpriteRenderer deco_r_renderer;
	private SpriteRenderer table_renderer;

	void Awake() {
		load_renderers();
	}
	
    void Start() {
		draw();
	}

	void load_renderers() {
		bg_renderer = GameObject.Find("Scene/Background/Wall").GetComponent<SpriteRenderer>();
		deco_l_renderer = GameObject.Find("Scene/Foreground/Decoration (Left)").GetComponent<SpriteRenderer>();
		deco_r_renderer = GameObject.Find("Scene/Foreground/Decoration (Right)").GetComponent<SpriteRenderer>();
		table_renderer = GameObject.Find("Scene/Foreground/Table").GetComponent<SpriteRenderer>();
	}

	void draw() {
		bg_renderer.sprite = bg_sprites[bg_index];
		deco_l_renderer.sprite = deco_sprites[deco_l_index];
		deco_r_renderer.sprite = deco_sprites[deco_r_index];
		table_renderer.sprite = table_sprites[table_index];
	}

	public void change_bg() { // TODO: this
		bg_index = (bg_index + 1) % bg_sprites.Length;
		draw();
	}

	public void change_deco_l() {
		deco_l_index = (deco_l_index + 1) % deco_sprites.Length;
		draw();
	}

	public void change_deco_r() {
		deco_r_index = (deco_r_index + 1) % deco_sprites.Length;
		draw();
	}

	public void change_table() {
		table_index = (table_index + 1) % table_sprites.Length;
		draw();
	}	
}

