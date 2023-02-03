namespace SurvivalProj
{
    public class Character
    {
        private string name;
        private int hp;

        public string GetName() => name;

        public int GetHP() => hp;

        public Character(string name, int hp = 1)
        {
            this.name = name;
            this.hp = hp;
        }
    }
}