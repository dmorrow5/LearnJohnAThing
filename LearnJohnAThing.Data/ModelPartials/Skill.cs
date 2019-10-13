using System;

namespace LearnJohnAThing.Data
{
    public partial class Skill
    {
        #region Properties
        //private string _name = "Basic Attack";
        //public string Name
        //{
        //    get
        //    {
        //        return this._name;
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            this._name = value;
        //        }
        //    }
        //}

        //private int _cost = 3;
        //public int Cost
        //{
        //    get
        //    {
        //        return this._cost;
        //    }
        //    set
        //    {
        //        if (value > 0)
        //        {
        //            this._cost = value;
        //        }
        //    }
        //}

        //private int _damage = 3;
        //public int Damage
        //{
        //    get
        //    {
        //        return this._damage;
        //    }
        //    set
        //    {
        //        if (value > 0)
        //        {
        //            this._damage = value;
        //        }
        //    }
        //}

        //private double _accuracy = 99;
        //public double Accuracy
        //{
        //    get
        //    {
        //        return this._accuracy;
        //    }
        //    set
        //    {
        //        if (0 < value && value <= 1)
        //        {
        //            this._accuracy = value;
        //        }
        //    }
        //}
        #endregion

        #region Constructors
        public Skill(int damage)
        {
            Cost = 5;
            Damage = damage;
            Accuracy = 1;

        }

        public Skill(string name, int cost, int damage, double accuracy)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Accuracy = accuracy;
        }
        #endregion
    }
}
