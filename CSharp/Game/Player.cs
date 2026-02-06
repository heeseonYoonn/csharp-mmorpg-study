namespace TextRPG.Game
{
    public class Player : Creature
    {
        public JobType JobType { get; private set; }
        public string JobName { get; private set; }


        //초기 세팅
        public Player(string playerName, JobType jobType)
        {
            switch (jobType)
            {
                case JobType.Knight:
                    MaxHp = 100;
                    AttackPower = 10;
                    JobName = "기사";
                    break;

                case JobType.Archer:
                    MaxHp = 75;
                    AttackPower = 12;
                    JobName = "궁수";
                    break;

                case JobType.Mage:
                    MaxHp = 50;
                    AttackPower = 15;
                    JobName = "마법사";
                    break;

                default:
                    MaxHp = 0;
                    AttackPower = 0;
                    break;
            }

            JobType = jobType;
            Name = playerName;
            CurrentHp = MaxHp;

        }
    }
}

