using System;
using HsiuHsien.Entity;

namespace lib
{
    public class Battle
    {
        static public string StartFight(Character ch, Monster mns){
            if(ch.ASPD >= mns.ASPD){
                while(Int32.Parse(ch.HP) > 0 && Int32.Parse(mns.HP) > 0){
                    mns = ChAttMns(ch, mns);
                    ch = MnsAttCh(mns, ch);
                }
            }else{
                while(Int32.Parse(ch.HP) > 0 && Int32.Parse(mns.HP) > 0){
                    ch = MnsAttCh(mns, ch);
                    mns = ChAttMns(ch, mns);
                }
            }
            if(Int32.Parse(ch.HP) > Int32.Parse(mns.HP)){
                return "Win";
            }else if(Int32.Parse(ch.HP) < Int32.Parse(mns.HP)){
                return "Lose";
            }else{
                return "Draw";
            }
        }
        static private Monster ChAttMns(Character ch, Monster mns){
            Random rnd = new Random();
            int mnsHP = Int32.Parse(mns.HP);
            mnsHP -= ch.ATK + rnd.Next(ch.Critical) - rnd.Next(mns.DEF);
            mns.HP = mnsHP.ToString();
            return mns;
        }
        static private Character MnsAttCh(Monster mns, Character ch){
            Random rnd = new Random();
            int chHP = Int32.Parse(ch.HP);
            chHP -= mns.ATK + rnd.Next(mns.Critical) - rnd.Next(ch.DEF);
            ch.HP = chHP.ToString();
            return ch;
        }
    }
}
