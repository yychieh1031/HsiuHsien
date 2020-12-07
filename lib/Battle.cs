using System;
using System.Collections.Generic;
using HsiuHsien.Entity;

namespace lib
{
    public class Battle
    {
        //
        // Character vs Multiple Monsters *Not done yet
        // Issues - store data only to first monster
        //
        public static string StartFight(ref BattleReport btrpt){
            int mns_ASPD = 0, single = 0;
            List<string> attmeg = btrpt.message;
            // Clear Battle Report Message
            btrpt.message.Clear();
            // Get the Fastest Monster Attack Speed
            foreach(var i in btrpt.Mns_Dtl){
                if(mns_ASPD < i.ASPD){
                    mns_ASPD = i.ASPD;
                }
            }
            // Character Attack First
            if(btrpt.Ch_Dtl.ASPD >= mns_ASPD){
                while(Int32.Parse(btrpt.Ch_Dtl.HP) > 0 && single == 0){
                    btrpt.Mns_Dtl[0] = ChAttMns(btrpt.Ch_Dtl, btrpt.Mns_Dtl[0], ref attmeg);
                    foreach(var mns in btrpt.Mns_Dtl){
                        if(Int32.Parse(mns.HP)<=0){
                            single += 1;
                            break;
                        };
                        btrpt.Ch_Dtl = MnsAttCh(mns, btrpt.Ch_Dtl, ref attmeg);
                    }
                }
            }else{ // Moster Attack First
                while(Int32.Parse(btrpt.Ch_Dtl.HP) > 0 && single == 0){
                    btrpt.Ch_Dtl = MnsAttCh(btrpt.Mns_Dtl[0], btrpt.Ch_Dtl, ref attmeg);
                    foreach(var mns in btrpt.Mns_Dtl){
                        if(Int32.Parse(mns.HP)<=0){
                            single += 1;
                            break;
                        };
                        btrpt.Mns_Dtl[0] = ChAttMns(btrpt.Ch_Dtl, btrpt.Mns_Dtl[0], ref attmeg);
                    }
                }
            }
            if(Int32.Parse(btrpt.Ch_Dtl.HP) > Int32.Parse(btrpt.Mns_Dtl[0].HP)){
                btrpt.Ch_Dtl.EXP = (Convert.ToInt32(btrpt.Ch_Dtl.EXP) + Convert.ToInt32(btrpt.Mns_Dtl[0].re_EXP)).ToString();
                Ch_Sts.update(btrpt.Ch_Dtl);
                return "You Win !!";
            }else if(Int32.Parse(btrpt.Ch_Dtl.HP) < Int32.Parse(btrpt.Mns_Dtl[0].HP)){
                return "You Lose !!";
            }else{
                return "Draw";
            }
        }

        //
        // Character Attack Monster
        //
        static private Monster ChAttMns(Character ch, Monster mns, ref List<string> message){
            int damage = 0;
            Random rnd = new Random();
            int mnsHP = Int32.Parse(mns.HP);
            damage = ch.ATK + rnd.Next(ch.Critical) - rnd.Next(mns.DEF);
            mnsHP -= damage;
            mns.HP = mnsHP.ToString();
            string attmeg = string.Format("{0} deal {1} damage to {2}, {2} HP {3}", ch.Ch_Nm, damage, mns.Mns_Nm, mns.HP);
            message.Add(attmeg);
            return mns;
        }

        //
        // Monster Attack Character
        //
        static private Character MnsAttCh(Monster mns, Character ch, ref List<string> message){
            int damage = 0;
            Random rnd = new Random();
            int chHP = Int32.Parse(ch.HP);
            damage = mns.ATK + rnd.Next(mns.Critical) - rnd.Next(ch.DEF);
            chHP -= damage;
            ch.HP = chHP.ToString();
            string attmeg = string.Format("{0} deal {1} damage to {2}, {2} HP {3}", mns.Mns_Nm, damage, ch.Ch_Nm, ch.HP);
            message.Add(attmeg);
            return ch;
        }

        #region original attack method
        //
        // Character vs one Monster
        //
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

        //
        // Character Attack Monster
        //
        static private Monster ChAttMns(Character ch, Monster mns){
            int damage = 0;
            Random rnd = new Random();
            int mnsHP = Int32.Parse(mns.HP);
            damage = ch.ATK + rnd.Next(ch.Critical) - rnd.Next(mns.DEF);
            mnsHP -= damage;
            mns.HP = mnsHP.ToString();
            return mns;
        }

        //
        // Monster Attack Character
        //
        static private Character MnsAttCh(Monster mns, Character ch){
            int damage = 0;
            Random rnd = new Random();
            int chHP = Int32.Parse(ch.HP);
            damage = mns.ATK + rnd.Next(mns.Critical) - rnd.Next(ch.DEF);
            chHP -= damage;
            ch.HP = chHP.ToString();
            return ch;
        }
        #endregion
    }
}
