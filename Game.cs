using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    //敵の攻撃力・定義（ランダム）____
    public class Dice
    {
        public int Roll()
        {
            Random r = new Random();
            return r.Next(999, 4999);
        }
    }
}
