namespace lib.Preparation
{
    public class attribute
    {
        static public int[] allAttribute(int level, int bornPower, int bornBodyStrength, int learnPower, int learnBodyStrength){

            double basicAttack=(bornPower*1.5+learnPower*1.2)*level;
            double basicDefence=(bornBodyStrength*2.0+learnBodyStrength*1.5)*level;

            int[] atkAndDef = new int[] {(int)basicAttack,(int)basicDefence};
            
            return atkAndDef;
        }

    }
}