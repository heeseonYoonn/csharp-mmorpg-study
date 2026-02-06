namespace TextRPG.Game
{
    public class Monster : Creature
    {
        protected MonsterType monsterType;

        public Monster(MonsterType monsterType)
        {

            switch (monsterType)
            {
                case MonsterType.Slime:
                    MaxHp = 20;
                    AttackPower = 20;
                    Name = "슬라임";
                    break;
                case MonsterType.Orc:
                    MaxHp = 20;
                    AttackPower = 20;
                    Name = "오크";
                    break;
                case MonsterType.Skeleton:
                    MaxHp = 30;
                    AttackPower = 20;
                    Name = "스켈레톤";
                    break;
                default:
                    MaxHp = 0;
                    AttackPower = 0;
                    break;
            }
            
            this.monsterType = monsterType;
            CurrentHp = MaxHp;
        }
    }
}
