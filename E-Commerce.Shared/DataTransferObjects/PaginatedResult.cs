namespace E_Commerce.Shared.DataTransferObjects;

public record PaginatedResult<TResult>(int pageIndex, int PageCount, int TotalCount, IEnumerable<TResult> Data);

