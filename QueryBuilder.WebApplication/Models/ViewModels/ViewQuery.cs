using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.WebApplication.Models.ViewModels
{
    public enum ActionQuery { Create,Edit}
    public class ViewQuery
    {
       [Required(ErrorMessage ="Entre el nombre de la tabla")]
       public string path { get; set; }
       [Required(ErrorMessage = "Entre la consulta")]
        public string query { get; set; }
       
       public ActionQuery? action { get; set; }

    }

}
