using UnityEngine;

[ExecuteAlways]
public class Animal : MonoBehaviour
{
    public enum Breed { Lion, Tiger, BlackBear, GrizzlyBear, PolarBear, Panda, Elephant, Giraffe, Penguin, Wolf, Zebra, Moose, Gorilla, Chimpanzee, Alligator };
    public Breed breed;

    public string name;
    public enum Sex { Male, Female, Neuter }
    public Sex sex;
    [Range(0, 100)]
    public int hunger;
    [Range(0, 100)]
    public int toilet;
    [Range(0, 100)]
    public int play;
    [Range(0, 100)]
    public int love;
    public string foodRequired;

    void Update()
    {
        switch (breed)
        {
            case Breed.Lion:
            case Breed.Tiger:
            case Breed.GrizzlyBear:
            case Breed.Wolf:
            case Breed.Alligator:
                foodRequired = "Meat";
                break;
            case Breed.PolarBear:
            case Breed.Penguin:
                foodRequired = "Fish";
                break;
            case Breed.Elephant:
            case Breed.BlackBear:
            case Breed.Gorilla:
            case Breed.Chimpanzee:
                foodRequired = "Fruit";
                break;
            case Breed.Panda:
            case Breed.Giraffe:
            case Breed.Zebra:
            case Breed.Moose:
                foodRequired = "Plants";
                break;
        }
    }
}
