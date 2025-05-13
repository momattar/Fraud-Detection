using System.Text.Json.Serialization;

namespace PJJ.Models
{
    public class TransactionInput2
    {
        public float Dpd_5_cnt { get; set; }
        public float Dpd_15_cnt { get; set; }
        public float Dpd_30_cnt { get; set; }
        public float Close_loans_cnt { get; set; }
        public int Federal_district_nm { get; set; }
        public int Payment_type_0 { get; set; }
        public int Payment_type_1 { get; set; }
        public int Payment_type_2 { get; set; }
        public int Payment_type_3 { get; set; }
        public int Payment_type_4 { get; set; }
        public int Payment_type_5 { get; set; }
        public float Past_billings_cnt { get; set; }
        public float Score_1 { get; set; }
        public float Score_2 { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int Rep_loan_date_year { get; set; }
        public int Rep_loan_date_month { get; set; }
        public int Rep_loan_date_day { get; set; }
        public int Rep_loan_date_weekday { get; set; }
        public int First_loan_year { get; set; }
        public int First_loan_month { get; set; }
        public int First_loan_day { get; set; }
        public int First_loan_weekday { get; set; }
        public float? First_overdue_date_year { get; set; }
        public float? First_overdue_date_month { get; set; }
        public float? First_overdue_date_day { get; set; }
        public int First_overdue_date_weekday { get; set; }
        public int Has_delinquency { get; set; }
    }
}
