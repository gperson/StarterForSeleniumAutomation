using StarterForSeleniumAutomation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterForSeleniumAutomation.Constants
{
    public class ConstantStrings
    {
        public static string CONNECTION_STRING = "";

        public static string GetUrl()
        {
            //Sets the URL based on which environment is set in the ConstantTestProperties.cs
            if (TestEnvironment.QA == ConstantTestProperties.ENVIRONMENT)
                return "http://github.com/";
            else
                throw new NotImplementedException();
        }
    }
}
