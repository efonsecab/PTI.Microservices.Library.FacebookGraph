﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.Models.FacebookGraph.GetMyAlbums
{

    public class GetMyAlbumsResponse
    {
        public Datum[] data { get; set; }
        public Paging paging { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string created_time { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public string link { get; set; }
        public string description { get; set; }
    }

}
