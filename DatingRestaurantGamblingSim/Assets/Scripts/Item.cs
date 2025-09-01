using UnityEngine;

public enum Type { Furniture, Plant, Water, Painting, Light, Decoration };
public enum Theme { Diner, Modern, Aquatic, Classical, Bohemian, Gothic, Steampunk, Crystal };

public enum Quality { Jewelry, Natural, Expensive, Practical };

public enum Cuisine { Italian, Greek, Chinese };
public enum Dietary { Vegetarian };
public enum Ingredient { Apple, Banana, Coconut };
public enum Allergen { Peanuts, Wheat, Milk, Soy }; // no... dont do that...
public enum Flavor { Salty, Savory, Sweet, Spicy, Bland, Bitter, Sour };

public abstract class Item : ScriptableObject {
	public string itemName;
	[TextArea] public string desc;
	public Sprite icon;

	public override string ToString() {
		return itemName;
	}
}

[CreateAssetMenu(fileName = "Decor", menuName = "Item/Decor")]
public class Decor : Item {
	public Type[] types;
	public Theme[] themes;

	public override string ToString() {
		return base.ToString();
	}
}

public class Gift : Item {
	public Quality[] qualities;
}

public class Food : Item {
	public Cuisine[] cuisines;
	public Dietary[] dietaries;
	public Ingredient[] ingredients;
	public Allergen[] allergens;
	public Flavor[] flavors;
}