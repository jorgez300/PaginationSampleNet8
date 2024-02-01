namespace PaginationSampleNet8.Helper.Pagination
{
    public class PagingParameters
    {


        public int PageNumber { get; set; } = 1;
        public int MaxPageSize { get; set; } = 50;
        public bool All { get; set; } = false;
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

    public class PagedAdapter<T>
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

        public PagedAdapter(IQueryable<T> source, PagingParameters pagingParameters)
        {
            TotalCount = source.Count();
            PageSize = (pagingParameters.All) ? TotalCount : pagingParameters.PageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            CurrentPage = pagingParameters.PageNumber;
            Data.AddRange(source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList());
        }

    }
}
