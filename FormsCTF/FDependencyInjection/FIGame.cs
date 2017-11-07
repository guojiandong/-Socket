using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCTF.FDependencyInjection
{
    public partial class FIGame : Form
    {
        public FIGame()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            //生成怪物
            Monster monster1 = new Monster("小怪A", 50);
            Monster monster2 = new Monster("小怪B", 50);
            Monster monster3 = new Monster("关主", 200);
            Monster monster4 = new Monster("最终Boss", 1000);
            monster1.txtMsg = txtMsg;
            monster2.txtMsg = txtMsg;
            monster3.txtMsg = txtMsg;
            monster4.txtMsg = txtMsg;
            //生成角色
            Role role = new Role();

            //木剑攻击
            role.Weapon = new WoodSword();
            role.Attack(monster1);

            //铁剑攻击
            role.Weapon = new IronSword();
            role.Attack(monster2);
            role.Attack(monster3);

            //魔剑攻击
            MagicSword ms = new FormsCTF.MagicSword();
            ms.txtMsg = txtMsg;
            role.Weapon = ms;
            role.Attack(monster3);
            role.Attack(monster4);
            role.Attack(monster4);
            role.Attack(monster4);
            role.Attack(monster4);
            role.Attack(monster4);


            #region MyRegion
            ////生成怪物
            //Monster monster1 = new Monster("小怪A", 50);
            //Monster monster2 = new Monster("小怪B", 50);
            //Monster monster3 = new Monster("关主", 200);
            //Monster monster4 = new Monster("最终Boss", 1000);

            ////生成角色
            //Role role = new Role();
            //role.txtMsg = txtMsg;

            ////木剑攻击
            //role.WeaponTag = "WoodSword";
            //role.Attack(monster1);

            ////铁剑攻击
            //role.WeaponTag = "IronSword";
            //role.Attack(monster2);
            //role.Attack(monster3);

            ////魔剑攻击
            //role.WeaponTag = "MagicSword";
            //role.Attack(monster3);
            //role.Attack(monster4);
            //role.Attack(monster4);
            //role.Attack(monster4);
            //role.Attack(monster4);
            //role.Attack(monster4); 
            #endregion

        }
    }
}
