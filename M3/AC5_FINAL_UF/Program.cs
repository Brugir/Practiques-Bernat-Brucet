class Program{
    public static void Main(string[] args){

        // Random random= new Random();
        // int[] dices = DiceController.rollDices();

        int money = 50;
        int smallPotion = 0;
        int midPotion = 0;
        int bigPotion = 0;

        Inventory inventory = new Inventory(money, smallPotion, midPotion, bigPotion);

        int maxLife = 50;
        int playerLevel = 1;
        int powerLevel = 5;

        Player player = new Player(maxLife, playerLevel, powerLevel);

        bool active = true;
        
        // Console.Clear();

        while(active){
            
            
            Console.WriteLine($"\n---------------------------");
            Console.WriteLine($"1 - Buscar enemigo");        
            Console.WriteLine($"2 - Entrar a la tienda");
            Console.WriteLine($"3 - Ver tus estadisticas");
            Console.WriteLine($"4 - Ver inventario");
            
            Console.WriteLine($"5 - Retirar (Se borrará todo el progreso)");
            Console.WriteLine($"----------------------------");
                        
            int user = Convert.ToInt32(Console.ReadLine());

            switch(user){

                case 1:
                
                    Console.Clear();    
                    CombatLevel.levelCombat(player, inventory);
                    break;

                case 2:
                    Console.Clear();
                    
                    Shop.shopMenu(inventory);
                    break;

                case 3:
                    Console.Clear();
                    

                    Console.WriteLine($"\nTus estadisticas:");
                    Console.WriteLine($"Vida restante: {maxLife}");
                    Console.WriteLine($"Nivel: {playerLevel}");
                    Console.WriteLine($"Nivel poder: {powerLevel}");
                    
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine($"Dinero: {inventory.Money}");

                    Console.WriteLine($"\nPoción pequeña: {inventory.SmallPotion}");
                    Console.WriteLine($"Poción media: {inventory.MidPotion}");
                    Console.WriteLine($"Poción grande: {inventory.BigPotion}");
                    
                    break;


                case 5:

                    Console.WriteLine($"Hasta la proxima!");
                    active = false;
                    break;
                
                default:
                    Console.WriteLine($"Opción no valida");
                    Console.WriteLine($"---------------------------");
                    break;
            }
        }            
    }


}
