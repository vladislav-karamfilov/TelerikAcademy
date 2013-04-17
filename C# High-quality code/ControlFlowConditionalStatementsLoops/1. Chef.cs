public class Chef
{
    public void Cook()
    {
        Bowl bowl = GetBowl();
        
        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);
        
        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        //... 
    }

    private Carrot GetCarrot()
    {
        //...
    }

    private Potato GetPotato()
    {
        //...
    }

    private void Cut(Vegetable potato)
    {
        //...
    }
}