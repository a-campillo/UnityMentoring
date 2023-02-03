namespace SurvivalProj
{
    public struct Weapon
    {
        private string name;
        private int dp;

        public string GetName() => name;

        public int GetDP() => dp;

        public Weapon(string name, int dp = 1)
        {
            this.name = name;
            this.dp = dp;
        }
    }
}