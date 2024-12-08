class CombatLevel{

    public static void levelCombat(Player player, Inventory inventory){

        if(player.Level >= 25){

            Console.Clear();
            
            Console.WriteLine($"Ya eres nivel {player.Level}! Quieres enfrentarte al jefe?");
            Console.WriteLine($"1 - Si");
            Console.WriteLine($"2 - No");

            int user = Convert.ToInt32(Console.ReadLine());

            if (user == 1){
                BossCombat.combatBoss(player, inventory);
            }

            else{
                Combat.CombatMenu(player, inventory);
            }   
        }

        else{
            Combat.CombatMenu(player, inventory);
        }

    }


}