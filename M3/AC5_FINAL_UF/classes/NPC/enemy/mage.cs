class Mage : EnemyBase{
    public Mage(int life, int level, int damage) : base(life, level, damage){}

    // Función de probabilidad critico
    public static int chanceExtraDamage(int baseDamage){

        int number = DiceController.totalDice();
    
        if (number == 12){

            Console.WriteLine($"El mago realizó un ataque furioso! El hechizo que lanzó es mas poderoso!");
            return extraDamage(baseDamage);
        }
        else{
            Console.WriteLine($"El mago te atacó! Te ha hecho {baseDamage} de daño!");
            return baseDamage;
        }     
    }

    public static int extraDamage(int baseDamage){

        int totalDices = DiceController.totalDice();


        int totalDamage = totalDices + baseDamage;
        Console.WriteLine($"Hizo un total de {totalDamage}");
        

        return totalDamage;

    }
}