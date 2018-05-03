namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Expenditure
    {
        public int ID { get; set; }

        public int IDExpenditure { get; set; }

        public DateTime CreateDate { get; set; }

        public double Amount { get; set; }

        public virtual ExpenditureType ExpenditureType { get; set; }
    }
}
