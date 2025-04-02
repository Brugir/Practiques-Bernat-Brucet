class Archer : EnemyBase{
    public Archer(int life, int level, int damage) : base(life, level, damage){}

    public virtual int extraDamage(int baseDamage){

        int[] dices = DiceController.rollDices();

        int totalExtra = dices[0];

        int totalDamage = totalExtra + baseDamage;

        return totalDamage;

    }
}