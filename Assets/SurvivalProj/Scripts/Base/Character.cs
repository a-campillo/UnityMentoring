namespace SurvivalProj
{
    public class Character
    {
        private string name;
        private int hp;

        public string GetName() => name;

        public int GetHP() => hp;

        public void AlterHP(int val)
        {
            if (hp > 0)
            {
                hp += val;

                if (hp < 0)
                {
                    hp = 0;
                } 
            }
        }

        public Character(string name, int hp = 1)
        {
            this.name = name;
            this.hp = hp;
        }
    }
}