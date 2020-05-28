namespace Hugo_DeliveryApp
{
    public class Usuario
    {
        public int id_user { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public bool userType { get; set; }
        
        public Usuario()
        {
            id_user = 0;
            fullname = "";
            username = "";
            password = "";
            userType = false;
        }
    }
}