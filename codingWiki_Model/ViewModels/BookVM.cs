using codingWiki_Model.Models;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace codingWiki_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }  
   
    
    }
}
