using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Todo
{
    public class ListTodoVM
    {
        public int TodoId { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public DateTime Date { get; set; }
    }
}
