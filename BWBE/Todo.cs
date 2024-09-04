namespace BWBE;

public class Todo
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}

public class Ingredients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static List<Recipe> Ingredients = new List<Recipe>();
}