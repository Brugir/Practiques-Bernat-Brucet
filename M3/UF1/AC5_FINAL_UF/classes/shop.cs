using System.Security.Cryptography.X509Certificates;

class Shop{

    public static void shopMenu(Inventory inventory){

        bool active = true;

        while(active){
    
            Console.WriteLine($"1 - Pocion pequeña: 10$");
            Console.WriteLine($"2 - Pocion mediana: 75$");
            Console.WriteLine($"3- Pocion grande: 150$");
            Console.WriteLine($"4 - Volver al menu");

            Console.WriteLine($"\nDinero disponible: {inventory.Money}");

            int user = Convert.ToInt32(Console.ReadLine());
            
            switch(user){

                case 1:
                    
                    Console.Clear();
                    
                    Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine($"Intentar regatear el precio?");
                    Console.WriteLine($"Al intentar regatear, lanzarás un dado, si te sale un 6, tendrás un descuento a mitad de precio,\npero si te sale un 3, te quitará lo que vale la poción.");
                    Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    
                    Console.WriteLine($"\n1 - Si");
                    Console.WriteLine($"2 - No");
                    
                    int priceOption = Convert.ToInt32(Console.ReadLine());

                    if (priceOption == 1){

                        int[] dices = DiceController.rollDices();
                        int priceDice = dices[1];

                        if (priceDice == 6){
                            Console.Clear();
                            
                            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            
                            Console.WriteLine($"Dado: {priceDice}\n");

                            Console.WriteLine($"Has regateado con exito!");
                            Console.WriteLine($"Compraste la poción por 5 monedas\n");
                            
                            
                            inventory.SmallPotion += 1;
                            inventory.Money -= 5;
                            Console.WriteLine($"Dinero restante: {inventory.Money}");
                            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                            
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                            
                        }

                        else if (priceDice == 3){
                            Console.Clear();
                            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                            Console.WriteLine($"Dado: {priceDice}\n");

                            Console.WriteLine($"El vendedor se enojó!");
                            Console.WriteLine($"Te ha robado 10 monedas\n");
                            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                            
                            inventory.Money -= 10; 

                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }              
                        }

                        else{
                            Console.Clear();
                            Console.WriteLine($"Dado: {priceDice}\n");
                            
                            Console.WriteLine($"No has podido regatear!\n");
                        }
                        break;
                    }
                    else{

                        if(inventory.Money >= 10){
                            inventory.SmallPotion += 1;
                            inventory.Money -= 10;
                            Console.WriteLine($"Poción comprada!");
                            Console.WriteLine($"Dinero restante: {inventory.Money}");
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                        }

                        else{
                            Console.WriteLine($"No tienes suficiente dinero!");
                        
                        }
                    }

                    
                    break;

                case 2:

                    Console.Clear();
                    
                    Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine($"Intentar regatear el precio?");
                    Console.WriteLine($"Al intentar regatear, lanzarás un dado, si te sale un 6, tendrás un descuento a mitad de precio,\npero si te sale un 3, te quitará lo que vale la poción.");
                    Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    
                    Console.WriteLine($"\n1 - Si");
                    Console.WriteLine($"2 - No");
                    
                    int priceOption2 = Convert.ToInt32(Console.ReadLine());

                    if (priceOption2 == 1){

                        int[] dices = DiceController.rollDices();
                        int priceDice = dices[1];

                        if (priceDice == 6){
                            Console.Clear();
                            
                            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            
                            Console.WriteLine($"Dado: {priceDice}\n");

                            Console.WriteLine($"Has regateado con exito!");
                            Console.WriteLine($"Compraste la poción por 38 monedas\n");
                            
                            
                            inventory.MidPotion += 1;
                            inventory.Money -= 38;
                            Console.WriteLine($"Dinero restante: {inventory.Money}");
                            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                        }

                        else if (priceDice == 3){
                            Console.Clear();
                            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                            Console.WriteLine($"Dado: {priceDice}\n");
                            
                            Console.WriteLine($"El vendedor se enojó!");
                            Console.WriteLine($"Te ha robado 75 monedas\n");
                            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                            
                            inventory.Money -= 75;
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                        }

                        else{
                            Console.Clear();
                            Console.WriteLine($"Dado: {priceDice}");
                            
                            Console.WriteLine($"No has podido regatear!\n");
                        }
                        break;
                    }
                    else{

                        if(inventory.Money >= 75){
                            inventory.MidPotion += 1;
                            inventory.Money -= 75;
                            Console.WriteLine($"Poción comprada!");
                            Console.WriteLine($"Dinero restante: {inventory.Money}");
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                        }

                        else{
                            Console.WriteLine($"No tienes suficiente dinero!");
                        
                        }
                    }

                    break;

                case 3:

                if (inventory.Money <= 75){
                    Console.Clear();
                    
                    Console.WriteLine($"No tienes suficiente dinero!\n");
                    break;
                }

                else{

                    Console.Clear();
                    
                    Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine($"Intentar regatear el precio?");
                    Console.WriteLine($"Al intentar regatear, lanzarás un dado, si te sale un 6, tendrás un descuento a mitad de precio,\npero si te sale un 3, te quitará lo que vale la poción.");
                    Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    
                    Console.WriteLine($"\n1 - Si");
                    Console.WriteLine($"2 - No");
                    
                    int priceOption3 = Convert.ToInt32(Console.ReadLine());

                    if (priceOption3 == 1){

                        int[] dices = DiceController.rollDices();
                        int priceDice = dices[1];

                        if (priceDice == 6){
                            Console.Clear();
                            
                            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            
                            Console.WriteLine($"Dado: {priceDice}\n");

                            Console.WriteLine($"Has regateado con exito!");
                            Console.WriteLine($"Compraste la poción por 75 monedas\n");
                            
                            
                            inventory.BigPotion += 1;
                            inventory.Money -= 75;
                            Console.WriteLine($"Dinero restante: {inventory.Money}");
                            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                        }

                        else if (priceDice == 3){
                            Console.Clear();
                            Console.WriteLine($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                            Console.WriteLine($"Dado: {priceDice}\n");
                            
                            Console.WriteLine($"El vendedor se enojó!");
                            Console.WriteLine($"Te ha robado 150 monedas\n");
                            Console.WriteLine($"\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                            
                            inventory.Money -= 150;
                            if (inventory.Money <= 0){
                                inventory.Money = 0;
                            }
                        }

                        else{
                            Console.Clear();
                            
                            Console.WriteLine($"No has podido regatear!\n");
                        }
                        break;
                    }
                    else{

                        if(inventory.Money >= 150){
                            inventory.BigPotion += 1;
                            inventory.Money -= 150;
                            Console.WriteLine($"Poción comprada!");
                            Console.WriteLine($"Dinero restante: {inventory.Money}");
                        }

                        else{
                            Console.WriteLine($"No tienes suficiente dinero!");
                        
                        }
                    }

                    break;


                }

                    

                case 4:
                    Console.Clear();
                    
                    active = false;
                    break;
                
                default:
                    Console.Clear();
                
                    Console.WriteLine($"opcion no valida!");
                    break;


            }

        } 
    }

}