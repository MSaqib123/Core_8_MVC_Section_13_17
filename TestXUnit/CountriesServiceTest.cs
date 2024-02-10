using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXUnit
{
    public class CountriesServiceTest
    {
        private readonly ICountiesService _countiesService;
        public CountriesServiceTest(ICountiesService countiesService)
        {
            _countiesService = countiesService;
        }
        //========= 1. Arrange =============

        //========= 2. Act =============

        //========= 3. Assert =============

        //--- View => TestExplorer(CTR+E+T) => Run => se result
    }
}
