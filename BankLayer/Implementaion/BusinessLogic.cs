using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace BankLayer.Implementaion
{
    public class BusinessLogic
    {
        
        public BusinessLogic() {
           
        }
        public async Task<string> getfromlogic()
        {
            
            return await Task.FromResult("string");
        }

        public int getbalance()
        {
            return 1000;
        }
    }
}
