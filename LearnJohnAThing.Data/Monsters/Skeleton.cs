﻿namespace LearnJohnAThing.Data
{
    public class Skeleton : Monsters
    {
        #region Constructors
        public Skeleton()
        {
            this.Name = "Skeleton";
            this.MaxHP = 7;
            this.HP = 7;
            //this.Skill1 = new Skill(3);
        }
        #endregion
    }
}
