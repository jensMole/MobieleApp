using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimoteBeacons.Models
{
    public class Route
    {
        private int route_id;

        public int Route_Id
        {
            get { return route_id; }
            set { route_id = value; }
        }

        private string name_ln;

        public string Name_Ln
        {
            get { return name_ln; }
            set { name_ln = value; }
        }
    }
}
