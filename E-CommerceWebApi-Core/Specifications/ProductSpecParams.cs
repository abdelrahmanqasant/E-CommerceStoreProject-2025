using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Specifications
{
    public class ProductSpecParams
    {
        private const int _MaxPageSize = 50;
        private int _PageSize = 6;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > _MaxPageSize) ? _MaxPageSize : value;
        }
        private List<string> _brands { get; set; } = new();
        private List<string> _types { get; set; } = new();
        public List<string> Types
        {
            get => _types;
            set
            {
                _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        public List<string> Brands
        {
            get => _brands;
            set
            {
                _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }
        public string? Sort { get; set; }
        private string? _search;

        public string Search
        {
            get => _search ?? "";
            set => _search = value.ToLower();
        }

    }

}
