namespace TextRPG.Course
{
    class DataStructure
    {
        public void Run()
        {
            //List
            List<int> list = new List<int>();

            foreach (int element in list)
            {
                Console.WriteLine(element);
            }

            //Dictionary
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
            dic.Add(1, new Monster(1));
            dic[1] = new Monster(1);

            Monster mon;
            bool isFound = dic.TryGetValue(5, out mon);

            dic.Remove(5);
        }
    }

    class Monster
    {
        public int Id;
        public Monster(int id)
        {
            this.Id = id;
        }
    }
}
