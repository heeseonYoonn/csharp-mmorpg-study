namespace TextRPG.Game
{
    internal class GameProcess
    {
        static Random random = new Random();
        protected Player Player;

        //게임 초기 설정
        public void SetUpPlayer()
        {
            while (true)
            {
                string name = SetName();
                JobType jobType = SelectJob();
                Player = new Player(name, jobType);
                RPGSystem.Message($"{Player.Name} (직업:{Player.JobName}, HP:{Player.MaxHp}, ATTACK:{Player.AttackPower})");

                bool isPlayerCreated = IsPlayerCreationConfirmed();

                if (isPlayerCreated)
                    break;
                else
                    Player = null;
            }
        }

        //캐릭터 이름설정
        string SetName()
        {
            while (true)
            {
                RPGSystem.Message("캐릭터 이름을 입력하세요.");
                string input = RPGSystem.GetUserResponse();
                RPGSystem.EmptyLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                else
                    continue;
            }
        }

        //몬스터생성
        Monster CreateRandomMonster()
        {
            MonsterType monsterType;
            switch (random.Next(1, 4))
            {
                case 1:
                    monsterType = MonsterType.Orc;
                    break;
                case 2:
                    monsterType = MonsterType.Skeleton;
                    break;
                case 3:
                    monsterType = MonsterType.Slime;
                    break;
                default:
                    monsterType = MonsterType.None;
                    break;
            }

            Monster monster = new Monster(monsterType);
            Thread.Sleep(1000);
            RPGSystem.Warn($"{monster.Name} (HP:{monster.MaxHp}/ATTACK:{monster.AttackPower})이(가) 리스폰 되었습니다.");
            return monster;
        }

        //필드진입
        public void EnterField()
        {
            RPGSystem.Message("필드에 접속하였습니다.");
            while (true)
            {
                Monster monster = CreateRandomMonster();
                RPGSystem.ConsoleWrite("[1]전투모드로 돌입\n" +
                                    "[2]마을로 이동");
                string input = RPGSystem.GetUserResponse();
                RPGSystem.EmptyLine();

                switch (input)
                {
                    case "1":
                        Fight(monster);
                        if (Player.IsDead)
                            return;
                        else
                            break;
                    case "2":
                        return;
                    default:
                        continue;
                }

            }
        }

        //턴제 공격
        bool isTargetDeadAfterAttack(Creature attacker, Creature target)
        {
            attacker.Attack(target);
            RPGSystem.Message($"{attacker.Name} >> {target.Name} 공격 | " +
                            $"{target.Name}이(가) {attacker.AttackPower}의 피해를 입었다!");
            RPGSystem.ConsoleWrite($"[STATUS] {target.Name} HP:{target.CurrentHp}/{target.MaxHp}\n");

            if (target.IsDead)
            {
                if (target is Monster monster)
                    RPGSystem.Alert($"{target.Name}을(를) 처치하였습니다.\n");
                else
                {
                    RPGSystem.Alert($"{target.Name}이(가) 사망하였습니다.\n");
                    RPGSystem.Alert("마을로 돌아갑니다.\n");
                }

                return true;
            }
            else
                return false;
        }

        //전투
        void Fight(Monster monster)
        {
            while (true)
            {
                if (isTargetDeadAfterAttack(Player, monster))
                    break;
                if (isTargetDeadAfterAttack(monster, Player))
                    break;
            }
        }

        //캐릭터 생성 확인
        bool IsPlayerCreationConfirmed()
        {
            while (true)
            {
                RPGSystem.Message("캐릭터 생성을 완료하시겠습니까? (y/n)");
                string input = RPGSystem.GetUserResponse();
                RPGSystem.EmptyLine();

                switch (input)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        continue;
                }
            }
        }

        //가는 길 선택
        public DestinationType SelectDestination()
        {
            while (true)
            {
                RPGSystem.Message("어디로 가시겠습니까?");
                RPGSystem.ConsoleWrite("[1]로비\n[2]필드\n[3]상점\n[9]게임종료하기");

                string input = RPGSystem.GetUserResponse();
                RPGSystem.EmptyLine();

                switch (input)
                {
                    case "1":
                        return DestinationType.Lobby;
                    case "2":
                        return DestinationType.Field;
                    case "3":
                        return DestinationType.Store;
                    case "9":
                        return DestinationType.ExitGame;
                    default:
                        continue;
                }
            }
        }

        //직업 선택
        private JobType SelectJob()
        {
            while (true)
            {
                RPGSystem.Message("직업을 선택하세요.");
                RPGSystem.ConsoleWrite("[1]기사\n" +
                                       "[2]궁수\n" +
                                       "[3]마법사");
                string input = RPGSystem.GetUserResponse();
                RPGSystem.EmptyLine();

                switch (input)
                {
                    case "1":
                        return JobType.Knight;
                    case "2":
                        return JobType.Archer;
                    case "3":
                        return JobType.Mage;
                    default:
                        continue;
                }
            }

        }
    }
}
