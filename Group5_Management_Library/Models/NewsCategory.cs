using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class NewsCategory
    {
        public int NewsCategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<News> News { get; set; } = new List<News>();
    }
}
