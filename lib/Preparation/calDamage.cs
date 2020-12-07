namespace lib 
{
    public class calDamage
    {   
        // 0 無 1金 2木 3水 4火 5土
        public static int atkToEnemy(int myType, int enemyType, int myAtk, int enemyDef){

            int damage=enemyDef-myAtk;

            switch(myType){

                case 1:
                    damage=gold(enemyType,myAtk,enemyDef);
                    break;
                case 2:
                    damage=wood(enemyType,myAtk,enemyDef);
                    break;

                case 3:
                    damage=water(enemyType,myAtk,enemyDef);
                    break;
                case 4:
                    damage=fire(enemyType,myAtk,enemyDef);
                    break;
                case 5:
                    damage=earth(enemyType,myAtk,enemyDef);
                    break;
                defalut:
                    damage=myAtk-enemyDef;
                    break;


            }

            if (damage<=0){
                return 0; // in case the enemyDef too high so damage become negative then heal enemy
            }

            return damage;

        }

        private static int gold(int enemyType, int myAtk, int enemyDef){
            
            if(enemyType==2){
                return (int)(myAtk*2.5-enemyDef);
            }

            if(enemyType==3){
                return (int)(myAtk*0.5-enemyDef);
            }

            return myAtk-enemyDef;
        }
        private static int wood(int enemyType, int myAtk, int enemyDef){
           
            if(enemyType==5){
                return (int)(myAtk*2.5-enemyDef);
            }

            if(enemyType==4){
                return (int)(myAtk*0.5-enemyDef);
            }

            return myAtk-enemyDef;            
        }
        private static int water(int enemyType, int myAtk, int enemyDef){
            
            if(enemyType==4){
                return (int)(myAtk*2.5-enemyDef);
            }

            if(enemyType==2){
                return (int)(myAtk*0.5-enemyDef);
            }

            return myAtk-enemyDef;            
        }
        private static int fire(int enemyType, int myAtk, int enemyDef){
            
            if(enemyType==1){
                return (int)(myAtk*2.5-enemyDef);
            }

            if(enemyType==5){
                return (int)(myAtk*0.5-enemyDef);
            }

            return myAtk-enemyDef;           
        }
        private static int earth(int enemyType, int myAtk, int enemyDef){
            
            if(enemyType==3){
                return (int)(myAtk*2.5-enemyDef);
            }

            if(enemyType==1){
                return (int)(myAtk*0.5-enemyDef);
            }

            return myAtk-enemyDef;            
        }

    }
}