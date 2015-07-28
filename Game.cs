using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{

    class Program
    {
        static void Main()//実行ﾒｿｯﾄﾞ
        {
            //____①User情報・初期化（User）____
            Parameter.User U_001 = new Parameter.User() { Name = "もっちー", Gender = "male"  };
            Parameter.User U_002 = new Parameter.User() { Name = "宮崎"    , Gender = "male"  };
            Parameter.User U_003 = new Parameter.User() { Name = "ちゃっぴ", Gender = "female"};
            //____②Job情報・初期化（Job）____
            Parameter.Job J_001 = new Parameter.Job() { Name = "ナイト" };
            Parameter.Job J_002 = new Parameter.Job() { Name = "レンジャー" };
            Parameter.Job J_003 = new Parameter.Job() { Name = "ウィザード" };
            Parameter.Job J_004 = new Parameter.Job() { Name = "ハンター" };
            Parameter.Job J_005 = new Parameter.Job() { Name = "ウォーリア" };
            //____③武器情報・初期化（Weapon）____
            Parameter.Weapon W_001 = new Parameter.Weapon() { Name = "ライオンハート", Attack = 800 };
            Parameter.Weapon W_002 = new Parameter.Weapon() { Name = "エクスカリバー", Attack = 400 };
            Parameter.Weapon W_003 = new Parameter.Weapon() { Name = "オリハルコン"  , Attack = 200 };
            //____④防具情報・初期化（Guard）____
            Parameter.Guard G_001 = new Parameter.Guard() { Name = "イージスの盾"    , Defence = 500 };
            Parameter.Guard G_002 = new Parameter.Guard() { Name = "クリスタルメイル", Defence = 200 };
            Parameter.Guard G_003 = new Parameter.Guard() { Name = "ローブオブロード", Defence = 150 };

            //____ALL情報・初期化（Parson_Parameter）____
            Parameter.Parson_Parameter[] party =
            {
                new Parameter.Parson_Parameter()
                    { User = U_001, Hp = 20000,  Attack = 300, Defence = 50, Job = J_001, Guard = G_001, Weapon = W_001,},
                new Parameter.Parson_Parameter()
                    { User = U_002, Hp = 10000,  Attack = 200, Defence = 50, Job = J_002, Guard = G_002, Weapon = W_002,},
                new Parameter.Parson_Parameter()
                    { User = U_003, Hp = 5000,  Attack = 100, Defence = 50, Job = J_003, Guard = G_003, Weapon = W_003,}
            };


            //Person情報の出力ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
            //var=ジェネリック・クラス＿これくしょん
            var q = party.Select(c => new { charactor = c });

            foreach (var item in q)
            {
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー");
                Console.WriteLine("UserName    : {0,-10}\t\tUserGender : {1}",
                                    item.charactor.User.Name, item.charactor.User.Gender);
                Console.WriteLine("Job         : {0,-10}\t\tHP         : {1}", item.charactor.Job.Name, item.charactor.Hp);
                Console.WriteLine("Weapon Name : {0,-10}\t\tAttack     : {1}",
                                    item.charactor.Weapon.Name, item.charactor.Weapon.Attack);
                Console.WriteLine("Guard Name  : {0,-8}\t\tDefence    : {1}",
                                    item.charactor.Guard.Name, item.charactor.Guard.Defence);
            }


            //出力処理ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
            int i = 0;
            int NoHp = 0;

            while (true)
            {
            	
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー");
                Console.ReadLine();
                Console.WriteLine("【敵のターン】");
                Console.ReadLine();
                Console.WriteLine("モンスターの全体攻撃。");
                var dice = new Dice.Dice(); //System.Random.Next()による乱数計算
                int attack = dice.Roll();
                Console.ReadLine();
                Console.WriteLine("モンスターはすべてのメンバーに「{0}」の力で攻撃した。\n", attack);    //乱数の出力
                //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
                //敵の攻撃によるﾀﾞﾒｰｼﾞ計算の定義    //残りHPの定義
                var dam = party.Select(c =>       //LINQ機能____Party_Parameterを選択し、cに格納します。//from c in Party_Parameter//select new{};
                    new
                    {
                        charactor = c,//配列 charactor に partyが入っている
                        damage = attack - (c.Defence + c.Guard.Defence),

                    }
                );


                //敵の攻撃によるﾀﾞﾒｰｼﾞ計算・結果出力
                foreach (var Damage in dam)//damage in dam　を　damage in Damageにして各々取り出し
                {
                    if (Damage.charactor.Hp > 0)//HPがあれば実行
                    {
                        int nokoriHP;
                        nokoriHP = (Damage.charactor.Hp) - (Damage.damage);
//                        if (i == 0) { nokoriHP = (Damage.charactor.Hp) - (Damage.damage); }//1ターン目はHPからﾀﾞﾒｰｼﾞをひく
//                       else { nokoriHP = (Damage.charactor.shp) - (Damage.damage); }//2ターン目以降はshpからﾀﾞﾒｰｼﾞをひく

                        Console.ReadLine();

                        if (Damage.damage <= 1)//ﾀﾞﾒｰｼﾞが１以下なら、ﾀﾞﾒｰｼﾞ１
                        {
                            Console.WriteLine("{0}「{1}」は、「1」ダメージを受けた。"
                                , Damage.charactor.Job.Name, Damage.charactor.User.Name);
                        }
                        else
                        {
                            Console.WriteLine("{0}「{1}」は、「{2}」ダメージを受けた。"
                                , Damage.charactor.Job.Name, Damage.charactor.User.Name, Damage.damage);
                        }
                        if (nokoriHP <= 0)//残りHPが０以下なら、戦闘不能
                        {
                            Console.WriteLine("{0}は戦闘不能になりました", Damage.charactor.User.Name);
                            NoHp++;
                        }
                        else
                        {
                            Console.WriteLine("{0}の残りHPは{1}です", Damage.charactor.User.Name, nokoriHP);
                        }
                        Damage.charactor.Hp = nokoriHP;
                    }
                    else
                    {
                        Console.WriteLine("\n戦闘不能：{0,-8}", Damage.charactor.User.Name);
                    }
                }
                i++;
                
                if(NoHp==party.Length)
                {
                	Console.WriteLine("全員が戦闘不能になりました。");
                	Console.WriteLine("--------Game Over--------");
                	Console.WriteLine("コンティニューしますか？（No=0, Yes=1）");
                	Console.Write("入力：");
                	try{
	                	string s = Console.ReadLine();
	                	if(s=="0"){
		                	goto END;
	                	}
	                	if(s=="1"){
	                		continue;
	                	}
                	}
                	catch{
                		continue;
                	}
                }
            }
           END:
            





























            return;
        }
    }
}