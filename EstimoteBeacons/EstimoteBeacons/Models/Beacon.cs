using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimoteBeacons.Models
{
    public class Beacon
    {
        private int beacon_id;

        public int Beacon_Id
        {
            get { return beacon_id; }
            set { beacon_id = value; }
        }

        private string location_ln;

        public string Location_Ln
        {
            get { return location_ln; }
            set { location_ln = value; }
        }

        private string description_txt;

        public string Description_Txt
        {
            get { return description_txt; }
            set { description_txt = value; }
        }
    }
}
