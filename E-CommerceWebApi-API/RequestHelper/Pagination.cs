
using E_CommerceWebApi_Core.Entities;

namespace Mock_E_CommerceProject_API.RequestHelpers
    {
        public class Pagination<T>(int pageIndex, int pageSize, int count, IReadOnlyList<T> data) where T : BaseEntity
        {
            public int _PageSize { get; set; } = pageSize;
            public int _PageIndex { get; set; } = pageIndex;
            public int _Count { get; set; } = count;
            public IReadOnlyList<T> _Data { get; set; } = data;
        }
    }


