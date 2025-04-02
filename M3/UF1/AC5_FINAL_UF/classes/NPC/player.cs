class Player{

    public int Life {get; set;}
    public int Level {get; set;}
    public int PowerLevel {get; set;}

    public Player (int life, int level, int powerLevel){
        Life = life;
        Level = level;
        PowerLevel = powerLevel;
    }

    // public static void Attack(int totalDice){

    //     Random random = new Random();
    //     string[] ataquesFlojos = {"Pero que imbécil! Justo antes de pegarle te tropezaste con una roca!", "¿Solo eso?¿Por esta miseria vas al gym?", "Vaya pringao", "Los dioses de olimpio te han abandonado"};
    //     string[] ataquesMedios = {"Buena ostia bro", "Dale dale daleee!!!", "Nada mal"};
    //     string[] ataquesFuertes = {"¡Esa es! ¡Demuestra quien manda!", "¡Bomboclap! Esa no se la esperaba"};

    //     Console.WriteLine($"Tirando los dados!");
    //     Thread.Sleep(2000);

    //     if (totalDice <= 4){
    //         int mensajes = random.Next(1, ataquesFlojos.Length);
    //         Console.WriteLine(ataquesFlojos[mensajes]);
            
    //     } else if(totalDice >= 5 && 8 <= totalDice ){
    //         int mensajes = random.Next(1, ataquesMedios.Length);
    //         Console.WriteLine(ataquesMedios[mensajes]);
    //     } else if(totalDice >= 9){
    //         int mensajes = random.Next(1, ataquesFuertes.Length);
    //         Console.WriteLine(ataquesFuertes[mensajes]);
    //     }
    // }

}