using System;
using System.Globalization;

namespace Hugo_DeliveryApp
{
    public class Orden
    {
        public int idorder { get; set; }
        
        public DateTime createdate { get; set; }
        
        public int idproduct { get; set; }
        
        public int idaddres { get; set; }

        
        public Orden()
        {
            idorder = 0;
            createdate = DateTime.Now;
            idproduct = 0;
            idaddres = 0;
        }
    }
}