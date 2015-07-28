using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter
{

    ////////複数の値を参照して定義したい＿＿＿インスタンスを複数作りたい///////

    //____①User情報・定義（User）____
    public class User
    {
        public string Name;
        public string Gender;
    }
    //____②Job情報・定義（Job）____
    public class Job
    {
        public string Name;
    }
    //____③武器情報・定義（Weapon）____
    public class Weapon
    {
        public string Name;
        public int Attack;
    }
    //____④防具情報・定義（Guard）____
    public class Guard
    {
        public string Name;
        public int Defence;
    }

    ////////____ALL情報・定義（Parson_Parameter）____１つの値をそのまま定義したい////////

    public class Parson_Parameter
    {
        public User User;//①
        public Job Job;//②
        public int Hp;
        public int Attack;
        public int Defence;
        public Weapon Weapon;//③
        public Guard Guard;//④
    }
    
    ////////____敵情報・定義（Enemy_Parameter）____//////////
   
    public class Enemy_Parameter
    {
    	public string name;
        public int Hp;
        public int Attack;
        public int Defence;
    }
    
}
