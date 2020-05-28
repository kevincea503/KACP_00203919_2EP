namespace Hugo_DeliveryApp
{
    public class Direccion
    {
        public int idaddres { get; set; }
        public int iduser { get; set; }
        public string addres { get; set; }

        public Direccion()
        {
            idaddres = 0;
            iduser = 0;
            addres = "";
        }

    }
}