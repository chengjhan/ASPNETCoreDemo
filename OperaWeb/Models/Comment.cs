using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string UserName { get; set; }

        public string UserComment { get; set; }

        public DateTime LastModified { get; set; }

        public int OperaID { get; set; }

        public Opera Opera { get; set; }
    }
}
