namespace TextRPG.Game
{
    public class Creature
    {
        public string Name { get; protected set; }
        public int MaxHp { get; protected set; }
        public int AttackPower { get; protected set; }
        public int CurrentHp { get; protected set; }
        public bool IsDead { get; protected set; }

        public Creature()
        {
            IsDead = false;
        }

        public int OnDamaged(int damage)
        {
            CurrentHp = Math.Max(0, CurrentHp - damage);
            if (CurrentHp == 0)
                IsDead = true;

            return CurrentHp;
        }

        public void Attack(Creature target)
        {
            target.OnDamaged(AttackPower);
            Thread.Sleep(1000);
        }
    }
}
