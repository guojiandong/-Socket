using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF
{
    internal interface IAttackStrategy
    {
        void AttackTarget(Monster monster);
    }
    internal sealed class WoodSword : IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            monster.Notify(20);
        }
    }
    internal sealed class IronSword : IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            monster.Notify(50);
        }
    }
    internal sealed class MagicSword : IAttackStrategy
    {
        public TextBox txtMsg = null;
        private Random _random = new Random();

        public void AttackTarget(Monster monster)
        {
            int loss = (_random.NextDouble() < 0.5) ? 100 : 200;
            if (200 == loss)
            {
                txtMsg.Text += "出现暴击！！！\r\n";
                //Console.WriteLine("出现暴击！！！");
            }
            monster.Notify(loss);
        }
    }


    public class Monster
    {
        public TextBox txtMsg = null;
        /// <summary>
        /// 怪物名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 怪物的生命值
        /// </summary>
        private Int32 HP { get; set; }

        public Monster(String name, Int32 hp)
        {
            this.Name = name;
            this.HP = hp;
        }
        /// <summary>
        /// 怪物被攻击时，被调用的方法，用来处理被攻击后的状态更改
        /// </summary>
        /// <param name="hp"></param>
        public void Notify(int loss)
        {
            if (this.HP <= 0)
            {
                txtMsg.Text += "此怪物已死\r\n";
                return;
            }
            this.HP -= loss;
            if (this.HP <= 0)
            {
                txtMsg.Text += "怪物" + this.Name + "被打死\r\n";
            }
            else
            {
                txtMsg.Text += "怪物" + this.Name + "损失" + loss + "HP\r\n";
            }
        }
    }
    internal sealed class Role
    {
        /// <summary>
        /// 表示角色目前所持武器
        /// </summary>
        public IAttackStrategy Weapon { get; set; }
        /// <summary>
        /// 攻击怪物
        /// </summary>
        /// <param name="monster">被攻击的怪物</param>
        public void Attack(Monster monster)
        {
            this.Weapon.AttackTarget(monster);
        }
    }

    #region MyRegion
    ///// <summary>
    ///// 怪物
    ///// </summary>
    //public class Monster
    //{
    //    /// <summary>
    //    /// 怪物名称
    //    /// </summary>
    //    public String Name { get; set; }
    //    /// <summary>
    //    /// 怪物的生命值
    //    /// </summary>
    //    public int HP { get; set; }
    //    public Monster(String name, Int32 hp)
    //    {
    //        this.Name = name;
    //        this.HP = hp;
    //    }
    //}
    ///// <summary>
    ///// 角色
    ///// </summary>
    //public class Role
    //{
    //    public TextBox txtMsg = null;
    //    private Random _random = new Random();
    //    /// <summary>
    //    /// 表示角色目前所持武器的字符串
    //    /// </summary>
    //    public string WeaponTag { get; set; }
    //    /// <summary>
    //    /// 攻击怪物
    //    /// </summary>
    //    /// <param name="monster">被攻击的怪物</param>
    //    public void Attack(Monster monster)
    //    {
    //        if (monster.HP <= 0)
    //        {
    //            txtMsg.Text += "此怪物已死\r\n";
    //            return;
    //        }
    //        if ("WoodSword" == this.WeaponTag)
    //        {
    //            monster.HP -= 20;
    //            if (monster.HP <= 0)
    //            {
    //                txtMsg.Text += "攻击成功！怪物" + monster.Name + "已死亡\r\n";
    //            }
    //            else
    //            {
    //                txtMsg.Text += "攻击成功！怪物" + monster.Name + "损失20HP\r\n";
    //            }
    //        }
    //        else if ("IronSword" == this.WeaponTag)
    //        {
    //            monster.HP -= 50;
    //            if (monster.HP <= 0)
    //            {
    //                txtMsg.Text += "攻击成功！怪物" + monster.Name + "已死亡\r\n";
    //            }
    //            else
    //            {
    //                txtMsg.Text += "攻击成功！怪物" + monster.Name + "损失50HP\r\n";
    //            }
    //        }
    //        else if ("MagicSword" == this.WeaponTag)
    //        {
    //            int loss = (_random.NextDouble() < 0.5) ? 100 : 200;
    //            monster.HP -= loss;
    //            if (200 == loss)
    //            {
    //                txtMsg.Text += "出现暴击！！！\r\n";
    //            }

    //            if (monster.HP <= 0)
    //            {
    //                txtMsg.Text += "攻击成功！怪物" + monster.Name + "已死亡\r\n";
    //            }
    //            else
    //            {
    //                txtMsg.Text += "攻击成功！怪物" + monster.Name + "损失" + loss + "HP\r\n";
    //            }
    //        }
    //        else
    //        {
    //            txtMsg.Text += "角色手里没有武器，无法攻击！\r\n";
    //        }
    //    }
    //} 
    #endregion
}
