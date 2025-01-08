class EnemyBase {

    public int Life {get; set;}
    public int Level {get; set;}
    public int Damage {get; set;}

    public EnemyBase (int life, int level, int damage){
        Life = life;
        Level = level;
        Damage = damage;
    }

}