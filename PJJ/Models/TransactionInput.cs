namespace PJJ.Models
{
    public class TransactionInput
    {
        public string type { get; set; }
        public float amount { get; set; }
        public float oldbalanceOrg { get; set; }
        public float newbalanceOrig { get; set; }
        public float oldbalanceDest { get; set; }
        public float newbalanceDest { get; set; }
    }
}
