using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{
    public class MembersFundsList
    {
        public string MembersID { get; set; }
        public string MembersName { get; set; }
        public string SourceId { get; set; }
        public string SourceName { get; set; }
        public string Amount { get; set; }
    }
}