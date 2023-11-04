﻿Console.Title = "The Properties of Arrows";

Console.WriteLine("Let's Build an arrow!");
ArrowheadType myArrowhead = PickArrowheadType();
FletchingType myFletchingType = PickFletchingType();
float myShaftLength = PickShaftLength();

Arrow myArrow = new Arrow(myArrowhead, myFletchingType, myShaftLength);
Console.WriteLine($"The price of your arrow is: {myArrow.GetCost()} gold!");

ArrowheadType PickArrowheadType()
{
    Console.WriteLine("Which type of Arrowhead do you want? ");
    Console.WriteLine($"1 -> {ArrowheadType.Steel}");
    Console.WriteLine($"2 -> {ArrowheadType.Wood}");
    Console.WriteLine($"3 -> {ArrowheadType.Obsidian}");
    int numberChoice = Convert.ToInt32(Console.ReadLine());

    ArrowheadType typeChoice = numberChoice switch
    {
        1 => ArrowheadType.Steel,
        2 => ArrowheadType.Wood,
        3 => ArrowheadType.Obsidian,
    };
    return typeChoice;
}

FletchingType PickFletchingType()
{
    Console.WriteLine("Now, which type of Fletching do you want? ");
    Console.WriteLine($"1 -> {FletchingType.GooseFeather}");
    Console.WriteLine($"2 -> {FletchingType.Plastic}");
    Console.WriteLine($"3 -> {FletchingType.TurkeyFeather}");
    int numberChoice = Convert.ToInt32(Console.ReadLine());

    FletchingType typeChoice = numberChoice switch
    {
        1 => FletchingType.GooseFeather,
        2 => FletchingType.Plastic,
        3 => FletchingType.TurkeyFeather,
    };
    return typeChoice;
}

float PickShaftLength()
{
    float length = 0;
    while (length < 60 || length > 100)
    {
        Console.Write("How many centimeters between 60cm and 100cm long of shaft do you want? ");
        length = Convert.ToSingle(Console.ReadLine());
    }
    return length;
}

class Arrow
{
    public ArrowheadType Arrowhead { get; }
    public FletchingType Fletching { get; }
    public float ShaftLength { get; }
    
    public Arrow(ArrowheadType arrowHead, FletchingType fletchingType, float shaftLength)
    {
        Arrowhead = arrowHead;
        Fletching = fletchingType;
        ShaftLength = shaftLength;
    }

    public float GetCost()
    {
        float arrowFullPrice = 0;

        arrowFullPrice += Arrowhead switch
        {
            ArrowheadType.Steel => 10,
            ArrowheadType.Wood => 3,
            ArrowheadType.Obsidian => 5,
            _ => 0,
        };

        arrowFullPrice += Fletching switch
        {
            FletchingType.GooseFeather => 3,
            FletchingType.Plastic => 10,
            FletchingType.TurkeyFeather => 5,
            _ => 0,
        };
        arrowFullPrice += 0.05f * ShaftLength;
        return arrowFullPrice;
    }
}

enum ArrowheadType { Steel, Wood, Obsidian };
enum FletchingType { Plastic, TurkeyFeather, GooseFeather };