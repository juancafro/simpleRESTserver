using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRESTServer.Models
{
    public partial class Person 
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public float PayRate { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }

       
    }
}