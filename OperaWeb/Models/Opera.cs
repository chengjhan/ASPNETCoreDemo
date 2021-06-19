using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OperaWeb.Models
{
    public class Opera
    {
        [Display(Name = "編號")]
        public int OperaID { get; set; }

        [Display(Name = "歌劇名稱")]
        public string Title { get; set; }

        [Display(Name = "年代")]
        public int? Year { get; set; }

        [Display(Name = "作者")]
        public string Composer { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
