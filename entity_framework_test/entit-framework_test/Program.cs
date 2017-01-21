using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entit_framework_test
{
    class Program
    {
       

        static void Main(string[] args)
        {

            savvyEntities context_savvy  = new savvyEntities();



            //// 1) READ THE WHOLE TABLE:
            //List<result> objCountries = context_savvy.results.ToList<result>();

            //foreach (result r in objCountries)
            //{
            //    Console.WriteLine(r.PCB_ID1.ToString());
            //}




            //// 2) INSERT DATA:
            //result obj = new result();
            //obj.PCB_ID1 = "23";
            //obj.PIN = "1243";
            //context_savvy.results.Add(obj);
            //context_savvy.SaveChanges();



            // 3) UPDATE DATA:
            // najpej preberi
            // nato updataj!
            // var tmp = context_savvy.results.First(b => b.PCB_ID1 == "LTEK00000000");
            //var tmp = context_savvy.results.OrderByDescending(b => b.id).FirstOrDefault();     // updataj zadnjo vrstico. ok
            var tmp = context_savvy.results.OrderByDescending(b => b.id).FirstOrDefault(); 
            if (tmp != null)
            {
                tmp.MAC = "MALICA";
                tmp.RSSI = 11;
                //context_savvy.results.Add();
                context_savvy.SaveChanges();
            }




            var temp = from b in context_savvy.results where b.PCB_ID1 == "LTEK00000000" select b; // query all row where LTEK00000000
            List<result> objList = temp.ToList<result>();
            foreach (result o in objList)
            {
                Console.WriteLine(o.id.ToString());
            }



            // query ta zadnji row ki ima LTEK0000000
            var temp2 = context_savvy.results.Where(b => b.PCB_ID1 == "LTEK00000000").OrderByDescending(b => b.id).FirstOrDefault();  // query all row where LTEK00000000      
            Console.WriteLine(temp2.TIME_STAMP.ToString());



            // query ta zadnji row ki ima LTEK0000000 in TEST_RESULT PASS    OK
            var temp3 = context_savvy.results.Where(b => b.PCB_ID1 == "LTEK00000000" && b.ISSUE == "N/A").OrderByDescending(b => b.id).FirstOrDefault();  // query all row where LTEK00000000      
            Console.WriteLine(temp3.TIME_STAMP.ToString());








            Console.ReadKey();



        }
    }
}
