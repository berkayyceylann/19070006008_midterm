namespace _19070006008_midterm.Services
{
    public class PaginationService
    {
        private const int MAX_PAGE_SIZE = 10;
        private const int MIN_PAGE_SIZE = 1;
        public int MinPageSize { get; set; }
        public int MaxPageSize { get; set; }
        
        public PaginationService()
        {
            this.MinPageSize = MIN_PAGE_SIZE;
            this.MaxPageSize = MAX_PAGE_SIZE;
        }

        public PaginationService(int min, int max)
        {
            this.MinPageSize = min < MIN_PAGE_SIZE ? MIN_PAGE_SIZE : min;
            this.MaxPageSize = max > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : max;
        }
    }
}
