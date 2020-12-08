using System;
namespace lib 
{
    public class calDamage
    {   
        // 0 無 1金 2木 3水 4火 5土
        public static int atkToEnemy( int myType, int enemyType, int myAtk, int enemyDef){
            int damage = 0;
            switch(myType){
                case 1:
                    return damage = gold( enemyType, myAtk, enemyDef);
                case 2:
                    return damage = wood( enemyType, myAtk, enemyDef);
                case 3:
                    return damage = water( enemyType, myAtk, enemyDef);
                case 4:
                    return damage = fire( enemyType, myAtk, enemyDef);
                case 5:
                    return damage = earth( enemyType, myAtk, enemyDef);
                default:
                    return damage = myAtk - enemyDef < 0 ? 0 : myAtk - enemyDef;
            }
        }

        private static int gold(int enemyType, int myAtk, int enemyDef){
            if(enemyType==2){
                return (int)(myAtk*2.5-enemyDef);
            }
            return enemyDef-myAtk;
        }
        private static int wood(int enemyType, int myAtk, int enemyDef){
            if(enemyType==5){
                return (int)(myAtk*2.5-enemyDef);
            }
            return enemyDef-myAtk;            
        }
        private static int water(int enemyType, int myAtk, int enemyDef){
            if(enemyType==4){
                return (int)(myAtk*2.5-enemyDef);
            }
            return enemyDef-myAtk;            
        }
        private static int fire(int enemyType, int myAtk, int enemyDef){
            if(enemyType==1){
                return (int)(myAtk*2.5-enemyDef);
            }
            return enemyDef-myAtk;            
        }
        private static int earth(int enemyType, int myAtk, int enemyDef){
            if(enemyType==3){
                return (int)(myAtk*2.5-enemyDef);
            }
            return enemyDef-myAtk;            
        }

    }
}