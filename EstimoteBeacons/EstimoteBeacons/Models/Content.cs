using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimoteBeacons.Models
{
    public class Content
    {
        private int beacon_content_id;

        public int Beacon_Content_Id
        {
            get { return beacon_content_id; }
            set { beacon_content_id = value; }
        }

        private string metatype_sn;

        public string Metatype_Sn
        {
            get { return metatype_sn; }
            set { metatype_sn = value; }
        }

        private string content_txt;

        public string Content_Txt
        {
            get { return content_txt; }
            set { content_txt = value; }
        }

    }
}
