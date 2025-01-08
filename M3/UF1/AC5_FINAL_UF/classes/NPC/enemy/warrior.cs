class Warrior : EnemyBase{
    public Warrior(int life, int level, int damage) : base(life, level, damage){}

    public virtual int extraDamage(int baseDamage){

        int totalDices = DiceController.totalDice();

        int totalDamage = totalDices + baseDamage;

        return totalDamage;

    }
}