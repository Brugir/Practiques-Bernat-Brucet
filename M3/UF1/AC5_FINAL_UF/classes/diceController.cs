class DiceController{

    public static int[] rollDices(){

        int[] allDices = new int[2];

        Random random = new Random();

        allDices[0] = random.Next(1, 7);
        allDices[1] = random.Next(1, 7);

        return allDices;
    } 

    public static int totalDice(){

        int[] dices = DiceController.rollDices();

        int total = dices[0] + dices[1];

        return total;
    }

   
}