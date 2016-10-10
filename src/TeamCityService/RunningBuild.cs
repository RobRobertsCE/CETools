using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityService
{ 

    public class RunningBuild
    {
        public int count { get; set; }
        public string href { get; set; }
        public List<Build> build { get; set; }

        public class Build
        {
            public int id { get; set; }
            public string buildTypeId { get; set; }
            public string number { get; set; }
            public string status { get; set; }
            public string state { get; set; }
            public bool running { get; set; }
            public int percentageComplete { get; set; }
            public string branchName { get; set; }
            public string href { get; set; }
            public string webUrl { get; set; }
        }
    }

}
