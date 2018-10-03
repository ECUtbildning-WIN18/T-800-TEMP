using System;
using System.Collections.Generic;
namespace T800.Domain
{
    class UploadList
    {
        public List<Person> KillList { get; set; }
        public Robot Killer { get; set; }
        public UploadList(List<Person> killList, Robot killer)
        {
            KillList = killList;
            Killer = killer;
            Killer.KillList = KillList;
        }
    }
}
