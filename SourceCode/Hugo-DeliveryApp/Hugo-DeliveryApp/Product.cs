namespace Hugo_DeliveryApp
{
    public class Product
    {
        public int id_product { get; set; }
        public int id_business { get; set; }
        public string name { get; set; }
        
        
        public Product()
        {
            id_product = 0;
            name = "";
        }
    }
}