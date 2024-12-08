class Inventory{

    public int Money {get; set;}
    public int SmallPotion {get; set;}
    public int MidPotion {get; set;}
    public int BigPotion {get; set;}

    public Inventory(int money, int smallPotion, int midPotion, int bigPotion){
        Money = money;
        SmallPotion = smallPotion;
        MidPotion = midPotion;
        BigPotion = bigPotion;
    }

    // static void healSmallPotion(Player player, Inventory inventory){
    //     player.Life += 5; 
    //     inventory.SmallPotion -= 1;

    //     if (player.Life >= 150){
    //         player.Life = 150; 
    //     }
    // }

    // static void healMidPotion(Player player, Inventory inventory){
    //     player.Life += 20;
    //     inventory.MidPotion -= 1;

    //     if (player.Life >= 150){
    //         player.Life = 150; 
    //     }
    // }

    // static void healBigPotion(Player player, Inventory inventory){
    //     player.Life += 75;
    //     inventory.BigPotion -= 1;

    //     if (player.Life >= 150){
    //         player.Life = 150; 
    //     }
    // }

    public static void Bagpack(Inventory inventory, Player player){

        
        bool active = true;

        while(active){

            Console.Clear();
        
            Console.WriteLine($"Que objeto quieres utilizar?");

            Console.WriteLine($"1 - Poción pequeña: {inventory.SmallPotion}");
            Console.WriteLine($"2 - Poción media: {inventory.MidPotion}");
            Console.WriteLine($"3 - Poción grande: {inventory.BigPotion}");
            Console.WriteLine($"4 - Volver atrás");

            int user = Convert.ToInt32(Console.ReadLine());

            switch(user){
                
                case 1:

                    if (inventory.SmallPotion == 0){

                        Console.WriteLine($"No tienes pociones pequeñas!");
                        
                    }

                    else {
                        inventory.SmallPotion -= 1;
                        player.Life += 10;
                        Console.WriteLine($"Te has curado 10 de vida!");
                        
                    }

                    break;

                case 2:
                    if (inventory.MidPotion == 0){

                        Console.WriteLine($"No tienes pociones medianas!");
                        
                    }

                    else {
                        inventory.MidPotion -= 1;
                        player.Life += 50;
                        Console.WriteLine($"Te has curado 50 de vida!");
                        
                    }

                    break;
                
                case 3:
                if (inventory.BigPotion == 0){

                        Console.WriteLine($"No tienes pociones grandes!");
                        
                    }

                    else {
                        inventory.MidPotion -= 1;
                        player.Life += 85;
                        Console.WriteLine($"Te has curado 85 de vida!");
                        
                    }
                    break;
                
                case 4:
                    Console.Clear();
                    active = false;
                    break;

            }

        }

    }


}