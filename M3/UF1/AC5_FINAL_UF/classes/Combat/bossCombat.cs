class BossCombat {

    public static void combatBoss(Player player, Inventory inventory){

        int[] dices = DiceController.rollDices();
        
        Random random= new Random();


        int level = random.Next(1, 25);

        int mageLife = level;
        int warriorLife = level + 15;
        int archerLife = level + 5;

        int damage = level/2;

        Mage mage = new Mage(mageLife, level, damage);
        Warrior warrior = new Warrior(warriorLife, level, damage);
        Archer archer = new Archer(archerLife, level, damage);

        EnemyBase[] enemies = {mage, warrior, archer};

        var spawnEnemy = enemies[random.Next(enemies.Length)];

        // Console.WriteLine($"Apareció un {spawnEnemy} de nivel {spawnEnemy.Level}\n");
        // Console.WriteLine($"Que quieres hacer?");
        // Console.WriteLine($"1 - Atacar");
        // Console.WriteLine($"2 - Ver estadisticas del enemigo");
        // Console.WriteLine($"3 - Huir");
        Console.WriteLine($"Apareció un {spawnEnemy} de nivel {spawnEnemy.Level}\n");

        bool active = true;

        while(active){
            
            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Bicho: {spawnEnemy}  Vida: {spawnEnemy.Life}>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
            
            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Player level: {player.Level}  Vida: {player.Life}/50>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            
            Console.WriteLine($"Que quieres hacer?");
            Console.WriteLine($"1 - Atacar");
            // Console.WriteLine($"2 - Ver estadisticas del enemigo");
            Console.WriteLine($"2 - Abrir inventario");
            
            Console.WriteLine($"3 - Huir");

            int user = Convert.ToInt32(Console.ReadLine());

            switch(user){

                case 1:
                    Console.Clear();
                    int enemyDice = DiceController.totalDice();
                    int playerDice = DiceController.totalDice();

                    Console.WriteLine($"Has lanzado tu dado!\n");
                    Console.WriteLine($"Tu dado: {playerDice}");
                    Console.WriteLine($"Dado enemigo: {enemyDice}\n");

                    if (playerDice > enemyDice){     
                        
                        if (playerDice >= 9){
                
                            int extraDamage = playerDice/2;

                            Console.WriteLine($"Daño critico! Has hecho {extraDamage} de daño extra!\n");

                            AttackMassage(playerDice);
                            spawnEnemy.Life = spawnEnemy.Life - player.PowerLevel;
                            spawnEnemy.Life = spawnEnemy.Life - extraDamage;
                        }

                        else if(playerDice >= 5 && playerDice <= 8){
                                                    
                            AttackMassage(playerDice);

                            spawnEnemy.Life = spawnEnemy.Life - player.PowerLevel;
                        }

                        else{
                            int nerfDamage = playerDice/2;
                            int nerfAttack = player.PowerLevel-nerfDamage;

                            Console.WriteLine($"Daño flojo! Has realizado {nerfAttack} de daño!");
                            AttackMassage(playerDice);

                            spawnEnemy.Life = spawnEnemy.Life - nerfAttack;
                        }
                        
                    } 
                    else if (playerDice == enemyDice){
                        
                        spawnEnemy.Life = spawnEnemy.Life -2;
                        player.Life = player.Life -2;
                    }
                    else{

                        EnemyAttackMassage(enemyDice);

                        player.Life = player.Life - spawnEnemy.Damage;
                    }
                    break;

                case 2:
                    Console.Clear();
                    Inventory.Bagpack(inventory, player);
                    // Console.WriteLine($"Estadisticas del {spawnEnemy}:\n");
                    // Console.WriteLine($"Vida: {spawnEnemy.Life}");
                    // Console.WriteLine($"Nivel: {spawnEnemy.Level}");
                    // Console.WriteLine($"Ataque: {spawnEnemy.Damage}\n");

                    // Console.WriteLine($"\nTus estadisticas:");
                    // Console.WriteLine($"Vida restante: {player.Life}");
                    // Console.WriteLine($"Nivel: {player.Level}");
                    // Console.WriteLine($"Nivel poder: {player.PowerLevel}");
                    break;
                
                case 3:
                    Console.Clear();
                    
                    Console.WriteLine($"Has huido!");
                    active = false;
                    break;
                
                default:
                    break;

            }

            if (spawnEnemy.Life <= 0){
                Console.WriteLine($"Has ganado el combate!");
                player.Level += 1;
                inventory.Money += 100;
                active = false;
            }

            if (player.Life <= 0){
                Console.WriteLine($"Has perdido el combate!");
                active = false;
            }

        }     
    }

    public static void AttackMassage(int totalDice){

        Random random = new Random();
        string[] ataquesFlojos = {"Pero que imbécil! Justo antes de pegarle te tropezaste con una roca!", "¿Solo eso?¿Por esta miseria vas al gym?", "Vaya pringao", "Los dioses de olimpio te han abandonado"};
        string[] ataquesMedios = {"Buena ostia bro", "Dale dale daleee!!!", "Nada mal"};
        string[] ataquesFuertes = {"¡Esa es! ¡Demuestra quien manda!", "¡Bomboclap! Esa no se la esperaba"};

        // Thread.Sleep(2000);

        if (totalDice <= 4){
            int mensajes = random.Next(0, ataquesFlojos.Length);
            Console.WriteLine(ataquesFlojos[mensajes]);
            
        } else if(totalDice >= 5 && totalDice <= 8){
            int mensajes = random.Next(0, ataquesMedios.Length);
            Console.WriteLine(ataquesMedios[mensajes]);
        } else if(totalDice >= 9){
            int mensajes = random.Next(0, ataquesFuertes.Length);
            Console.WriteLine(ataquesFuertes[mensajes]);
        }
    }

    public static void EnemyAttackMassage(int totalDice){

        Random random = new Random();
        string[] ataquesFlojos = {$"Esquivo tu ataque y te ha contratacado un golpe leve!", "Te hizo miniataque"};
        string[] ataquesMedios = {$"Te ha atacado!", "Toma ostia"};
        string[] ataquesFuertes = {$"Tremendo ostión te ha pegao!", "Fuopa, el enemigo realizó un ataque furioso"};

        // Thread.Sleep(2000);

        if (totalDice <= 4){
            int mensajes = random.Next(0, ataquesFlojos.Length);
            Console.WriteLine(ataquesFlojos[mensajes]);
            
        } else if(totalDice >= 5 && totalDice <= 8){
            int mensajes = random.Next(0, ataquesMedios.Length);
            Console.WriteLine(ataquesMedios[mensajes]);
        } else if(totalDice >= 9){
            int mensajes = random.Next(0, ataquesFuertes.Length);
            Console.WriteLine(ataquesFuertes[mensajes]);
        }

    }

}  

    


