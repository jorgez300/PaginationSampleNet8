namespace PaginationSampleNet8.Models.Pagination
{
    public class PagingParameters
    {


        public int PageNumber { get; set; } = 1;
        public int MaxPageSize { get; set; } = 50;
        private int _PageSize { get; set; } = 10;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public PagingParameters()
        {
        }

    }

    public class PagedList<T>
    {

        private int _CurrentPage { get; set; } = 1;
        public int CurrentPage {
            get {
                return _CurrentPage;
            }
            set {
                if (value > TotalPages)
                {
                    _CurrentPage = TotalPages;
                }
                else if (value < 1)
                {
                    _CurrentPage = 1;
                }
                else {
                    _CurrentPage = value;
                }
            } 
        }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public List<T> Data { get; set; } = new List<T>();

        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            TotalCount = source.Count();
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            CurrentPage = pageNumber;
            Data.AddRange(source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList());
        }

    }
}
